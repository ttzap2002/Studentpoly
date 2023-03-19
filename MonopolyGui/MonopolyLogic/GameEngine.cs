using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MonopolyData;
using MonopolyGui;
using MonopolyGui.Actions;

namespace MonopolyLogic
{
    /// <summary>
    /// Game Engine main alghoritm
    /// 1. Run action from ActionStack 
    /// 2. if empty generate all possible action for the current player
    /// 3. decided if a player is a bancrupt
    /// 
    /// </summary>
    public class GameEngine
    {
        Queue<GameAction> _gameActions;
        GameStatus _gameStatus;
        FeeAndPriceCalculator _calc;
        List<GameAction> _possibleGameActions;
        CardContainer _cardContainer;
        bool _isAutosaveOptionAvalaibe;
        static private GameEngine _Engine;

        public GameStatus GameStatus { get => _gameStatus; set => _gameStatus = value; }
        public CardContainer CardContainer { get => _cardContainer; }

        public bool IsAutosaveOptionAvalaibe { get => _isAutosaveOptionAvalaibe; set => _isAutosaveOptionAvalaibe = value; }


        public static GameEngine Engine
        {
            get
            {
                if (_Engine == null)
                {
                    _Engine = new GameEngine();
                }
                return _Engine;
            }
        }
        public static Player CurrentPlayer
        {
            get
            {
                return Engine._gameStatus.GetCurrentPlayer();
            }
        }

        public FeeAndPriceCalculator Calc { get => _calc; set => _calc = value; }

        GameEngine()
        {
            _gameStatus = new GameStatus();
            _calc = new FeeAndPriceCalculator();
            _gameActions = new Queue<GameAction>();
            _cardContainer = new CardContainer();
            _isAutosaveOptionAvalaibe= false;
        }


        List<GameAction> PossibleAction()
        {
            return new List<GameAction>();
        }

        public void AddAction(GameAction action)
        {
            _gameActions.Enqueue(action);
        }

        /// <summary>
        /// Główna metoda gry Studentpoly, jeżeli w kolejce jest jakać akcja do wykonania to ją wykonaj w przeciwnym wypadku wygeneruj możliwe akcje
        /// </summary>
     
        async public void RunGame()
        {
            while (_gameActions.Count > 0)
            {
                GameAction a = _gameActions.Dequeue();
                await Task.Run(() => a.Run());
            }
            GeneratePossibleUserActions();
        }



        /// <summary>
        /// Ta metoda generuje możliwe akcje jakie gracz jest w stanie wykonać następujące akcje
        /// jeżeli jest w więzieniu to generuja akcje dla więziennych akcji
        /// jeżeli nie to generuje normalne akcje
        /// Dodaje do panelu akcji listę wszystkich możliwych akcji
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        /// 


        public void GeneratePossibleUserActions()
        {
            _possibleGameActions = new List<GameAction>();
            if (_gameStatus.GetCurrentPlayer().IsPrisoner())
            {
                GeneratePrisonActions();
            }
            else
            {
                GenerateNormalMoveActions();
            }

            MainWindow.Instance.ActionPanel.CreateActionButtons(_possibleGameActions);
            // pokaż panel z przyciskami
            MainWindow.Instance.ListBoxWithAction.Visibility = Visibility.Visible;
        }

        private void GenerateNormalMoveActions()
        {
            if (_gameStatus.History.HasMovedInTheTurn())
            {
                if (_gameStatus.History.HasMandatoryAction())
                {

                    MandatoryAction ma = _gameStatus.History.MandatoryAction;
                    if (IsBankrupt(ma.Amount))
                    {
                        AddAction(new BanckruptAction());
                        RunGame();
                        return;
                    }
                    _possibleGameActions.Add(new PlayerPaysToPlayerAction(null, $"Zapłać {ma.Amount} zł", ma.PayTo, ma.Amount));

                }
                else
                {
                    if (_gameStatus.History.IsLastThrowDouble())
                    {
                        _possibleGameActions.Add(new DiceThrowAndMoveAction());
                    }
                    else
                    {
                        _possibleGameActions.Add(new EndOfTurnAction());
                    }
                    // jesli stoi na czyms co mozna kupic to buy property action
                    Player currrentPlayer = _gameStatus.GetCurrentPlayer();
                    Field thisField = _gameStatus.GetField(currrentPlayer.Coordinates);
                    if (thisField is PropertyField)
                    {
                        PropertyField thisPropertyField = (PropertyField)thisField;
                        if (thisPropertyField.Owner == EPlayerId.Bank)
                        {
                            _possibleGameActions.Add(new CanBuyPropertyAction(thisPropertyField));
                        }
                    }

                }
            }
            else
            {
                _possibleGameActions.Add(new DiceThrowAndMoveAction());
                if (_gameStatus.History.HousesBought < 3)
                {
                    BuyHouseOptions();
                }
            }
            SellPayDebtOptions();

        }

        private void BuyHouseOptions()
        {
            Player currentPlayer = _gameStatus.GetCurrentPlayer();
            List<PropertyField> all = _gameStatus.GetAllPropertiesOwnedBy(currentPlayer.PlayerId);
            foreach (PropertyField propertyField in all)
            {
                if (propertyField is StreetField)
                {
                    StreetField st = (StreetField)propertyField;
                    if (playerHasUnion(currentPlayer, st) && st.NoOfHouse < 5)
                    {
                        _possibleGameActions.Add(new BuyHouseAction(st));
                    }
                }
            }
        }

        private void SellPayDebtOptions()
        {
            Player currentPlayer = _gameStatus.GetCurrentPlayer();
            List<PropertyField> all = _gameStatus.GetAllPropertiesOwnedBy(currentPlayer.PlayerId);
            foreach (PropertyField propertyField in all)
            {
                if (propertyField.IsMortgage)
                {  // splata kredytow lub sprzedaz
                    int toPay = (int)((propertyField.Price / 2) * 1.1);
                    if (currentPlayer.Wallet >= toPay)
                    {
                        _possibleGameActions.Add(new PayDebtAction(propertyField, toPay));
                    }
                    _possibleGameActions.Add(new SellMortgagedPropertyAction(propertyField));
                }
                else
                {
                    if (propertyField is StreetField)
                    {
                        StreetField sf = (StreetField)propertyField;
                        if (sf.NoOfHouse == 0)
                        {// zastaw
                            _possibleGameActions.Add(new MortgageAction(sf));
                        }
                        else
                        { // sprzedaj dom
                            _possibleGameActions.Add(new SellHouseAction(sf));
                        }
                    }
                    if (propertyField is RailwayField || propertyField is UtilityField)
                    {
                        _possibleGameActions.Add(new MortgageAction(propertyField));
                    }
                }
            }
        }

        private bool IsBankrupt(int amount)
        {
            if (_gameStatus.GetCurrentPlayer().Wallet < amount)
            {
                // spraw czy jest wlascicielem
                List<PropertyField> propertyFields = _gameStatus.GetAllPropertiesOwnedBy(_gameStatus.GetCurrentPlayer().PlayerId);
                return (propertyFields.Count == 0) && (_gameStatus.GetCurrentPlayer().ExitPrisonCards == 0);
            }
            return false;
        }

        private void GeneratePrisonActions()
        {
            if (_gameStatus.GetCurrentPlayer().ExitPrisonCards > 0)
            {
                _possibleGameActions.Add(new UseCardAndExitPrisonAction());
            }
            if (_gameStatus.GetCurrentPlayer().Wallet >= 50)
            {
                _possibleGameActions.Add(new PayToExitPrisonAction());
            }
            _possibleGameActions.Add(new ThrowDoubleToExitPrisonAction());

        }

        /// <summary>
        /// sprawdza czy gracz ma całą unie 
        /// </summary>
        /// <param name="currentPlayer"></param>
        /// <param name="st"></param>
        /// <returns></returns>
        private bool playerHasUnion(Player currentPlayer, StreetField st)
        {
            List<List<int>> mainList = new List<List<int>>()
            {
                new List<int>(){1,3 },
                new List<int>(){6,8,9 },
                new List<int>(){11,13,14},
                new List<int>(){16,18,19},
                new List<int>(){21,23,24},
                new List<int>(){26,27,29},
                new List<int>(){31,32,34},
                new List<int>(){37,39}
            };
            foreach(List<int> l in mainList)
            {
                bool retVal = true;
                if( l.Contains(st.Coordinates))
                {
                    foreach(int i in l)
                    {
                        retVal = retVal && ((PropertyField)_gameStatus.GetField(i)).Owner == currentPlayer.PlayerId;
                    }
                    return retVal;
                }
            }
            return false;
        }

    }
}
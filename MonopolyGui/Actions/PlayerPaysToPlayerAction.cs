using MonopolyData;
using MonopolyLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGui.Actions
{
    public class PlayerPaysToPlayerAction : GameAction
    {
        EPlayerId _whoget;
        int _moneyToPay;
        public PlayerPaysToPlayerAction(string imagesource, string actionlabel,EPlayerId whoget, int moneyToPay) : base(imagesource, actionlabel)
        {
            _whoget = whoget;
            _moneyToPay = moneyToPay;

        }

        public override void Run()
        {
            Player CurrentPlayer = GameEngine.Engine.GameStatus.GetCurrentPlayer();
            Player Owner = GameEngine.Engine.GameStatus.GetPlayer(_whoget); 
            DisplayTN($"Gracz {CurrentPlayer.Name} płaci graczowi {Owner.Name} {_moneyToPay} kasy");
            if (CurrentPlayer.Wallet >= _moneyToPay)
            {
                CurrentPlayer.Wallet -= _moneyToPay;
                Owner.Wallet += _moneyToPay;
                MainWindow.PlaySound("kasa");
                GameEngine.Engine.GameStatus.History.MandatoryAction = null;
            }
            else 
            {
                GameEngine.Engine.GameStatus.History.RegisterMandatoryAction(Owner.PlayerId, _moneyToPay);
            }
            MainWindow.Instance.RefreshPlayerInfo();
        }


    }
}

using MonopolyLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGui.Actions
{
    public class PlayerGetFromBankAction : GameAction
    {
        int _amount;

        public PlayerGetFromBankAction(string imagesource, string actionlabel, int amount) : base(imagesource, actionlabel)
        {
            _amount = amount;
        }


        public override void Run()
        {
            DisplayTN($"Otrzymujesz {_amount} od banku");
            MainWindow.PlaySound("kasa");
            GameEngine.Engine.GameStatus.GetCurrentPlayer().Wallet += _amount;

            RefreshScreen();
        }

    }
}

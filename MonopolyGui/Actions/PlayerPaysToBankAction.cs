using MonopolyLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGui.Actions
{

    public class PlayerPaysToBankAction : GameAction
    {
        int amount;

        public PlayerPaysToBankAction(string imagesource, string actionlabel, int amount) : base(imagesource, actionlabel)
        {
            this.amount = amount;
        }

        public override void Run()
        {
            if(GameEngine.Engine.GameStatus.GetCurrentPlayer().Wallet>=amount)
            {
                GameEngine.Engine.GameStatus.GetCurrentPlayer().Wallet-=amount;
                DisplayTN($"Płacisz {amount} do banku");
                MainWindow.PlaySound("kasa");
            } 
            else
            {
                DisplayTN("Nie masz tyle pieniędzy. Może coś zastawisz, sprzedasz?");
                GameEngine.Engine.GameStatus.History.RegisterMandatoryAction(MonopolyData.EPlayerId.Bank, amount);
            }
            RefreshScreen();
        }



    }
}

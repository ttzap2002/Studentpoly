using MonopolyLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGui.Actions
{
    public class GoXSquaresAction : GameAction
    {
        int _noOfSteps;
        public GoXSquaresAction(string imagesource, string actionlabel, int noOfSteps) : base(imagesource, actionlabel)   
        {
            _noOfSteps = noOfSteps;
        }

        public override void Run()
        {
            DisplayTN();
            MainWindow.Instance.movePlayer(_noOfSteps);
            GameAction newAction = ActionFactory.CreateGameAction(GameEngine.Engine.GameStatus.GetCurrentPlayer().Coordinates);
            RefreshScreen();
            GameEngine.Engine.AddAction(newAction);
        }

    }
}

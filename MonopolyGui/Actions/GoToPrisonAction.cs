using MonopolyLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGui.Actions
{
    public class GoToPrisonAction : GameAction
    {
        public GoToPrisonAction(string imagesource, string actionlabel) : base(imagesource, actionlabel) { }
      

        public override void Run()
        {
            GameEngine.Engine.GameStatus.GetCurrentPlayer().TurnsToStayInPrison = 3;
            GameEngine.Engine.GameStatus.GetCurrentPlayer().Coordinates = 10;
            this.DisplayTN();
            RefreshScreen();
            GameEngine.Engine.AddAction(new EndOfTurnAction());

        }
    }
}

using MonopolyLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGui.Actions
{
    public class GoToAction : GameAction
    {

        int _fieldId;


        public GoToAction(string imagesource, string actionlabel, int field) : base(imagesource, actionlabel)
        {
            _fieldId= field;
        }

        public override void Run()
        {
            DisplayTN();
            int startPosition = GameEngine.CurrentPlayer.Coordinates;
            GameAction newAction = ActionFactory.CreateGameAction(_fieldId);
            int step=_fieldId-startPosition;
            if (step < 0) {
                step = 40 + step;
                GameEngine.Engine.AddAction(new StartPassingAction());
            }
            MainWindow.Instance.movePlayer(step);
            RefreshScreen();
            GameEngine.Engine.AddAction(newAction);
        }

    }
}

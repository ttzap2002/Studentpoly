using MonopolyLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGui.Actions
{
    public class LeavePrisonAction : GameAction
    {
        string _text;
        public LeavePrisonAction(string imagesource, string actionlabel, string text) : base(imagesource, actionlabel)
        {
            _text = text;
        }


        public override void Run()
        {
            GameEngine.CurrentPlayer.ExitPrisonCards += 1;
            DisplayTN();
            RefreshScreen();

        }
    }
}

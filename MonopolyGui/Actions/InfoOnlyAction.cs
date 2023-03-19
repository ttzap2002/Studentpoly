using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGui.Actions
{
    public class InfoOnlyAction : GameAction
    {
        public InfoOnlyAction(string imagesource, string actionlabel) : base(imagesource, actionlabel)
        {

        }

        public override void Run()
        {
            DisplayTN();
        }
    }
}

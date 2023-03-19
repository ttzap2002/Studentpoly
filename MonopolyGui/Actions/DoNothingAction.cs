using System.Windows.Documents;

namespace MonopolyGui.Actions
{
    public class DoNothingAction : GameAction
    {
        public DoNothingAction() : base(null, null) { }

        public override void Run()
        {
            //DO nothing by design
        }
    }
}
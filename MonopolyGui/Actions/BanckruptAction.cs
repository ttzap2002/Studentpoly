using MonopolyLogic;
using MonopolyData;

namespace MonopolyGui.Actions
{
    public class BanckruptAction :GameAction
    {
        public BanckruptAction(): base(null,"Bankrutujesz!")
        {
        }

        public override void Run()
        {
            Player p = GameEngine.CurrentPlayer;
            p.IsActive = false;
            p.Wallet = 0;
            DisplayTN("Nie masz wystarczająco dużo pieniędzy.\nRodzice się na ciebie obrazili.\nBankrutujesz! \nBędziesz musiał zaczą normalnie studiować :(");
            GameEngine.Engine.AddAction(new EndOfTurnAction());
            RefreshScreen();
        }
    }
}
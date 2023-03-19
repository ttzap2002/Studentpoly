using MonopolyLogic;

namespace MonopolyGui.Actions
{
    public class PayToExitPrisonAction : GameAction
    {
        public PayToExitPrisonAction() : base("", "Zapłać 50 za super lek na kaca") { }

        public override void Run()
        {
            GameEngine.Engine.GameStatus.GetCurrentPlayer().Wallet -= 50;
            GameEngine.Engine.GameStatus.GetCurrentPlayer().TurnsToStayInPrison = 0;
            DisplayShortTN("Jesteś super zdrowy. Kac wyleczony :)");
            RefreshScreen();
        }
    }
}
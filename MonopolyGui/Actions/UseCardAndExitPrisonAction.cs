using MonopolyLogic;

namespace MonopolyGui.Actions
{
    public class UseCardAndExitPrisonAction : GameAction
    {
        public UseCardAndExitPrisonAction() : base("", "Użyj leku na kaca") { }

        public override void Run()
        {
            GameEngine.Engine.GameStatus.GetCurrentPlayer().ExitPrisonCards -= 1;
            GameEngine.Engine.GameStatus.GetCurrentPlayer().TurnsToStayInPrison = 0;
            DisplayShortTN("Ten lek na kaca jest suuuper!!!");
            RefreshScreen();
        }
    }
}
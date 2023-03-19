using MonopolyLogic;
using System;
using System.Reflection.Emit;
using System.Threading;

namespace MonopolyGui.Actions
{
    public class StartPassingAction : GameAction
    {
        private static string txt = "Przechodzisz przez Start i otrzymujesz 200 złotych";
        public StartPassingAction() : base(null, txt) { }

        public override void Run()
        {
            GameEngine.Engine.GameStatus.GetCurrentPlayer().Wallet += 200;
            RefreshScreen();
            DisplayTN();            
        }
    }
}
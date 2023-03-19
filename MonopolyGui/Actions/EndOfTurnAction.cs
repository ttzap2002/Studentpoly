using MonopolyData;
using MonopolyLogic;
using System;
using System.Windows.Documents;

namespace MonopolyGui.Actions
{
    public class EndOfTurnAction : GameAction
    {
        public EndOfTurnAction() : base(null, "Koniec tury!") { }


        public override void Run() 
        {
            DisplayShortTN();
            GameEngine.Engine.GameStatus.ChangeTurn();
            if (GameEngine.Engine.IsAutosaveOptionAvalaibe)
            {
                GameStatus.SaveToFile($"Autosave.xml", GameEngine.Engine.GameStatus);
            }
        }
    }
}
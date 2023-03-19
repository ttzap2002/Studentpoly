using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGui.Actions
{
    public class ActionFactory
    {
        private static List<int> _chanceIDs = new List<int>() { 7, 22, 36 };
        private static List<int> _sTreasureIDs = new List<int>() { 2, 17, 33};
        private static List<int> _neutralField = new List<int>() { 0, 10, 20 };
        
        public static GameAction CreateGameAction(int boardID)
        {
            if (_neutralField.Contains(boardID)) { return new DoNothingAction(); }
            if (_chanceIDs.Contains(boardID)) { return new GetChanceCardAction(); }
            if (_sTreasureIDs.Contains(boardID)) { return new GetSTreasureCardAction(); }
            if( boardID == 4 ) { return new PlayerPaysToBankAction(null, "To był bardzo ciężki rok. Płacisz za warunek 200zł", 200); }
            if (boardID == 38) { return new PlayerPaysToBankAction(null, "Złapał cię kanar. Płacisz 100zł", 100); }
            if ( boardID == 30 ) { return new GoToPrisonAction(null, "Ale masz kaca... musisz odpocząć!"); }
            return new VisitPropertyAction();
        }
    }
}

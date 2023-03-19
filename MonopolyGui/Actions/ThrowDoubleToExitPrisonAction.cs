using MonopolyData;
using MonopolyLogic;
using System;
using System.Windows.Media.Animation;

namespace MonopolyGui.Actions
{
    internal class ThrowDoubleToExitPrisonAction : GameAction
    {
        public ThrowDoubleToExitPrisonAction(): base(null, "Rzuć dublet by szybciej wyleczyć kaca")
        {

        }

        public override void Run()
        {
            Random randomnumber = new Random();
            DiceThrowRecord record;
            record.FirstThrow = randomnumber.Next(1, 7);
            record.SecondThrow = randomnumber.Next(1, 7);
            GameStatus status = GameEngine.Engine.GameStatus;
            
            // rysuja na ekranie kostki
            MainWindow.Instance.Dispatcher.Invoke(new Action(() => { MainWindow.Instance.ShowImage(record); }));

            // sprawdzamy czy wychodzisz z wiezienia
            if (record.IsDouble())
            {
                GameEngine.Engine.AddAction(new InfoOnlyAction(null, "Kac wyleczony :) Jedziesz dalej..."));
                status.GetCurrentPlayer().TurnsToStayInPrison = 0;
            }
            else
            {
                GameEngine.Engine.AddAction(new InfoOnlyAction(null, "Dalej leczysz kaca..."));
                GameEngine.Engine.AddAction(new EndOfTurnAction());
            }
        }
    }
}
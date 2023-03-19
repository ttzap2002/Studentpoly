
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MonopolyData;
using MonopolyGui;
using MonopolyLogic;

namespace MonopolyGui.Actions
{
    public class DiceThrowAndMoveAction : GameAction
    {
        DiceThrowRecord record;

        public DiceThrowAndMoveAction() : base(null, "Rzut Kostką i ruch")
        {

        }


        void DiceThrow()
        {
            Random randomnumber = new Random();
            record.FirstThrow = randomnumber.Next(1, 7);
            record.SecondThrow = randomnumber.Next(1, 7);
            //record = MainWindow.Instance.getChatThrow();
                   
        }

        public override void Run()
        {
            GameStatus status = GameEngine.Engine.GameStatus;
            DiceThrow();
           
            // rysuja na ekranie kostki
            MainWindow.Instance.Dispatcher.Invoke(new Action(() => { MainWindow.Instance.ShowImage(record); }));

            //zapamietujemy ruch
            status.History.RegisterMove(record);

            // sprawdzamy czy idzie do wiezienia
            if (status.History.NumberOfDoubles() >= 3)
            {
                // idziesz do wiezienia
                GameEngine.Engine.AddAction(new GoToPrisonAction(null, "Idziesz leczyć kaca!"));
                
            } 
            else
            {
                if( status.GetCurrentPlayer().Coordinates + record.Sum()>39 ) 
                {
                    GameEngine.Engine.AddAction(new StartPassingAction());
                }
 
                
                MainWindow.Instance.movePlayer(record.Sum());
  
                int id = status.GetCurrentPlayer().Coordinates;
                GameEngine.Engine.AddAction(ActionFactory.CreateGameAction(id));    
            }



        }

    }
}
using MonopolyData;
using System.Collections.Generic;
using System.Windows.Media;
using MonopolyLogic;

namespace MonopolyGui.Actions
{
    public class HouseReconstructionAction : GameAction
    {
        int _costforhouse;
        int _costforhotel;


        public HouseReconstructionAction(string imagesource, string actionlabel, int costforhouse, int costforhotel) : base(imagesource, actionlabel)
        {
            _costforhouse = costforhouse;
            _costforhotel = costforhotel;
        }

        public override void Run()
        {
            int noOfHouse = 0;
            int noOfHotel = 0;

            DisplayTN();
            Player currentPlayer = GameEngine.CurrentPlayer;
            List<PropertyField> all = GameEngine.Engine.GameStatus.GetAllPropertiesOwnedBy(currentPlayer.PlayerId);
            foreach (PropertyField propertyField in all)
            {
                if (propertyField is StreetField)
                {
                    StreetField st = (StreetField)propertyField;
                    if( st.NoOfHouse==5)
                    {
                        noOfHotel++;
                    }
                    else
                    {
                        noOfHouse += st.NoOfHouse;
                    }
                    
                }
            }
            int toPay = noOfHouse * _costforhouse + noOfHotel * _costforhotel;
            if( toPay> 0 )
            {
                GameEngine.Engine.AddAction(
                    new PlayerPaysToBankAction(null, $"Koszty remontowe to {toPay}", toPay));
            }
            else
            {
                DisplayTN("Nie masz nic do remontowania.");
            }
        }
    }
}
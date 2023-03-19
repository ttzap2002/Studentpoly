using MonopolyData;
using MonopolyLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGui
{
    
    public class FeeAndPriceCalculator
    {
        // tablica zakupu



        // tablica oplat dla ulic ... bez domku, 1dom, 2 domy
        List<Hashtable> _chargeForStreets;
        // tablica cen domkow
        Hashtable _priceForHouse;

        // zwraca cene zakupu nieruchomosci
        // lub rzuca wyjatek jesli to nie jest property

        public FeeAndPriceCalculator() 
        {
            _priceForHouse = new Hashtable();
            _chargeForStreets = new List<Hashtable>();
            AddPropertyForStreets();
        }

        void AddPropertyForStreets() 
        {

            AddChargeForSingleStreet();
            AddChargeForOneHouseStreet();
            AddChargeFortwoHouseStreet();
            AddChargeForthreHouseStreet();
            AddChargeForFourHouseStreet();
            AddChargeForHotelStreet();
            AddPriceOfHouse();
        }

        void AddChargeForHotelStreet()
        {
            Hashtable hashtableForFourHouse = new Hashtable();

            hashtableForFourHouse.Add(1, 250);
            hashtableForFourHouse.Add(3, 450);
            hashtableForFourHouse.Add(6, 550);
            hashtableForFourHouse.Add(8, 550);
            hashtableForFourHouse.Add(9, 600);
            hashtableForFourHouse.Add(11, 750);
            hashtableForFourHouse.Add(13, 750);
            hashtableForFourHouse.Add(14, 900);
            hashtableForFourHouse.Add(16, 750);
            hashtableForFourHouse.Add(18, 950);
            hashtableForFourHouse.Add(19, 1000);
            hashtableForFourHouse.Add(21, 1050);
            hashtableForFourHouse.Add(23, 1050);
            hashtableForFourHouse.Add(24, 1100);
            hashtableForFourHouse.Add(26, 1155);
            hashtableForFourHouse.Add(27, 1150);
            hashtableForFourHouse.Add(29, 1200);
            hashtableForFourHouse.Add(31, 1275);
            hashtableForFourHouse.Add(32, 1275);
            hashtableForFourHouse.Add(34, 1400);
            hashtableForFourHouse.Add(37, 1500);
            hashtableForFourHouse.Add(39, 2000);

            _chargeForStreets.Add(hashtableForFourHouse);

        }


        void AddChargeForFourHouseStreet()
        {
            Hashtable hashtableForFourHouse = new Hashtable();

            hashtableForFourHouse.Add(1, 160);
            hashtableForFourHouse.Add(3, 320);
            hashtableForFourHouse.Add(6, 400);
            hashtableForFourHouse.Add(8, 400);
            hashtableForFourHouse.Add(9, 450);
            hashtableForFourHouse.Add(11, 625);
            hashtableForFourHouse.Add(13, 625);
            hashtableForFourHouse.Add(14, 705);
            hashtableForFourHouse.Add(16, 750);
            hashtableForFourHouse.Add(18, 750);
            hashtableForFourHouse.Add(19, 800);
            hashtableForFourHouse.Add(21, 875);
            hashtableForFourHouse.Add(23, 875);
            hashtableForFourHouse.Add(24, 925);
            hashtableForFourHouse.Add(26, 975);
            hashtableForFourHouse.Add(27, 975);
            hashtableForFourHouse.Add(29, 1025);
            hashtableForFourHouse.Add(31, 1100);
            hashtableForFourHouse.Add(32, 1100);
            hashtableForFourHouse.Add(34, 1200);
            hashtableForFourHouse.Add(37, 1300);
            hashtableForFourHouse.Add(39, 1700);

            _chargeForStreets.Add(hashtableForFourHouse);

        }


        void AddChargeForthreHouseStreet()
        {
            Hashtable hashtableForThreeHouse = new Hashtable();

            hashtableForThreeHouse.Add(1, 90);
            hashtableForThreeHouse.Add(3, 180);
            hashtableForThreeHouse.Add(6, 270);
            hashtableForThreeHouse.Add(8, 270);
            hashtableForThreeHouse.Add(9, 300);
            hashtableForThreeHouse.Add(11, 450);
            hashtableForThreeHouse.Add(13, 450);
            hashtableForThreeHouse.Add(14, 500);
            hashtableForThreeHouse.Add(16, 550);
            hashtableForThreeHouse.Add(18, 550);
            hashtableForThreeHouse.Add(19, 600);
            hashtableForThreeHouse.Add(21, 700);
            hashtableForThreeHouse.Add(23, 700);
            hashtableForThreeHouse.Add(24, 750);
            hashtableForThreeHouse.Add(26, 800);
            hashtableForThreeHouse.Add(27, 800);
            hashtableForThreeHouse.Add(29, 850);
            hashtableForThreeHouse.Add(31, 900);
            hashtableForThreeHouse.Add(32, 900);
            hashtableForThreeHouse.Add(34, 1000);
            hashtableForThreeHouse.Add(37, 1100);
            hashtableForThreeHouse.Add(39, 1400);

            _chargeForStreets.Add(hashtableForThreeHouse);

        }


        void AddChargeFortwoHouseStreet()
        {
            Hashtable hashtableForTwoHouseStreet = new Hashtable();

            hashtableForTwoHouseStreet.Add(1, 30);
            hashtableForTwoHouseStreet.Add(3, 60);
            hashtableForTwoHouseStreet.Add(6, 90);
            hashtableForTwoHouseStreet.Add(8, 90);
            hashtableForTwoHouseStreet.Add(9, 100);
            hashtableForTwoHouseStreet.Add(11, 150);
            hashtableForTwoHouseStreet.Add(13, 150);
            hashtableForTwoHouseStreet.Add(14, 180);
            hashtableForTwoHouseStreet.Add(16, 200);
            hashtableForTwoHouseStreet.Add(18, 200);
            hashtableForTwoHouseStreet.Add(19, 220);
            hashtableForTwoHouseStreet.Add(21, 250);
            hashtableForTwoHouseStreet.Add(23, 250);
            hashtableForTwoHouseStreet.Add(24, 300);
            hashtableForTwoHouseStreet.Add(26, 330);
            hashtableForTwoHouseStreet.Add(27, 330);
            hashtableForTwoHouseStreet.Add(29, 360);
            hashtableForTwoHouseStreet.Add(31, 390);
            hashtableForTwoHouseStreet.Add(32, 390);
            hashtableForTwoHouseStreet.Add(34, 450);
            hashtableForTwoHouseStreet.Add(37, 500);
            hashtableForTwoHouseStreet.Add(39, 600);

            _chargeForStreets.Add(hashtableForTwoHouseStreet);

        }

        void AddChargeForOneHouseStreet()
        {
            Hashtable hashtableForOneHouseStreet = new Hashtable();

            hashtableForOneHouseStreet.Add(1, 10);
            hashtableForOneHouseStreet.Add(3, 20);
            hashtableForOneHouseStreet.Add(6, 30);
            hashtableForOneHouseStreet.Add(8, 30);
            hashtableForOneHouseStreet.Add(9, 40);
            hashtableForOneHouseStreet.Add(11, 50);
            hashtableForOneHouseStreet.Add(13, 50);
            hashtableForOneHouseStreet.Add(14, 60);
            hashtableForOneHouseStreet.Add(16, 70);
            hashtableForOneHouseStreet.Add(18, 70);
            hashtableForOneHouseStreet.Add(19, 80);
            hashtableForOneHouseStreet.Add(21, 90);
            hashtableForOneHouseStreet.Add(23, 90);
            hashtableForOneHouseStreet.Add(24, 100);
            hashtableForOneHouseStreet.Add(26, 110);
            hashtableForOneHouseStreet.Add(27, 110);
            hashtableForOneHouseStreet.Add(29, 120);
            hashtableForOneHouseStreet.Add(31, 130);
            hashtableForOneHouseStreet.Add(32, 130);
            hashtableForOneHouseStreet.Add(34, 150);
            hashtableForOneHouseStreet.Add(37, 175);
            hashtableForOneHouseStreet.Add(39, 200);
            
            _chargeForStreets.Add(hashtableForOneHouseStreet);

        }

        void AddChargeForSingleStreet() 
        {
            Hashtable hashtableForSingleStreet = new Hashtable();

            hashtableForSingleStreet.Add(1, 2);
            hashtableForSingleStreet.Add(3, 4);
            hashtableForSingleStreet.Add(6, 6);
            hashtableForSingleStreet.Add(8, 6);
            hashtableForSingleStreet.Add(9, 8);
            hashtableForSingleStreet.Add(11, 10);
            hashtableForSingleStreet.Add(13, 10);
            hashtableForSingleStreet.Add(14, 12);
            hashtableForSingleStreet.Add(16, 14);
            hashtableForSingleStreet.Add(18, 14);
            hashtableForSingleStreet.Add(19, 16);
            hashtableForSingleStreet.Add(21, 18);
            hashtableForSingleStreet.Add(23, 18);
            hashtableForSingleStreet.Add(24, 20);
            hashtableForSingleStreet.Add(26, 22);
            hashtableForSingleStreet.Add(27, 22);
            hashtableForSingleStreet.Add(29, 24);
            hashtableForSingleStreet.Add(31, 26);
            hashtableForSingleStreet.Add(32, 26);
            hashtableForSingleStreet.Add(34, 28);
            hashtableForSingleStreet.Add(37, 35);
            hashtableForSingleStreet.Add(39, 50);
            
            _chargeForStreets.Add(hashtableForSingleStreet);

        }

        void AddPriceOfHouse() 
        {
            _priceForHouse.Add(1, 50);
            _priceForHouse.Add(3, 50);
            _priceForHouse.Add(6, 50);
            _priceForHouse.Add(8, 50);
            _priceForHouse.Add(9, 50);
            _priceForHouse.Add(11, 100);
            _priceForHouse.Add(13, 100);
            _priceForHouse.Add(14, 100);
            _priceForHouse.Add(16, 100);
            _priceForHouse.Add(18, 100);
            _priceForHouse.Add(19, 100);
            _priceForHouse.Add(21, 150);
            _priceForHouse.Add(23, 150);
            _priceForHouse.Add(24, 150);
            _priceForHouse.Add(26, 150);
            _priceForHouse.Add(27, 150);
            _priceForHouse.Add(29, 150);
            _priceForHouse.Add(31, 200);
            _priceForHouse.Add(32, 200);
            _priceForHouse.Add(34, 200);
            _priceForHouse.Add(37, 200);
            _priceForHouse.Add(39, 200);

        }



        public int GetBuyPrice(int coordinate) 
        {
            try 
            {
                PropertyField property = (PropertyField)GameStatus.Instance.BoardFields[coordinate];
                return property.Price;
            }
            catch 
            {
                throw new WrongTypeOfFieldException();
            }
        }
        
        

        //zwraca połowe ceny jesli nieruchomosc nie jest zastawion
        //ćwierć ceny jeśli zastawione
        public int GetSellPrice(int coordinate)
        {
            if (!((PropertyField)GameStatus.Instance.BoardFields[coordinate]).IsMortgage) 
            {
                return GetBuyPrice(coordinate)/2;
            }
            
                return GetBuyPrice(coordinate) / 4;
            
        }

        public int GetBuyHomePrice(int coordinate)
        {
            return (int) _priceForHouse[coordinate];
        }
        public int GetSellHomePrice(int coordinate) => (int)_priceForHouse[coordinate]/2;



        private int GetCharge(PropertyField property)
        {
            GameStatus currentStatus = GameEngine.Engine.GameStatus;
            int coordinate = property.Coordinates;
            if (property is StreetField)
            {
                int index = currentStatus.GetNoOfHouse(coordinate);
                return (int)(_chargeForStreets[index])[coordinate];
            }
            else if (property is RailwayField)
            {
                int[] toReurn = { 0, 25, 50, 100, 200 };

                int noOfRailways = currentStatus.GetNoOfRailway(property.Owner);
                return toReurn[noOfRailways];
            }
            // Utility here
            int noOfUtility = currentStatus.GetNoOfUtility(property.Owner);
            int throwScore = currentStatus.History.SumAllThrows();
            if(noOfUtility == 1) { return throwScore * 4;}
            if (noOfUtility == 2) { return throwScore * 10;}
            return 0;


        }

        public int GetFee(int coordinate, EPlayerId playerId)
        {
            // domy z talicy
            GameStatus actualGameStatus = GameStatus.Instance;
            PropertyField property = (PropertyField)actualGameStatus.BoardFields[coordinate];
            if (property.IsMortgage) { return 0; }
            if(playerId == property.Owner) { return 0; }
            return GetCharge(property); 
        }

    }

 
}

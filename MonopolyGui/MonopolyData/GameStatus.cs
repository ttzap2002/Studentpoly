using MonopolyGui.Actions;
using MonopolyLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Xml.Serialization;

namespace MonopolyData
{
    [Serializable]
    [XmlInclude(typeof(Player))]    
    [XmlInclude(typeof(Field))]
    [XmlInclude(typeof(StreetField))]
    [XmlInclude(typeof(PropertyField))]
    [XmlInclude(typeof(UtilityField))]
    [XmlInclude(typeof(RailwayField))]
    [XmlInclude(typeof(TurnHistory))]
    [XmlInclude(typeof(DiceThrowRecord))]
    [XmlInclude(typeof(MandatoryAction))]
    [XmlInclude(typeof(EPlayerId))]

    public class GameStatus 
    {

        List<Player> _players;
        List<Field> _boardFields;
        //int whoplay = 0;
        
        List<int> _chanceList;
        List<int> _societyTreasure;

        TurnHistory _history;
        //string _whoplayAsString;
        EPlayerId _whoplay;

        public List<Player> Players { get => _players; set => _players = value; }
        public List<Field> BoardFields { get => _boardFields; set => _boardFields = value; }
        public EPlayerId Whoplay { get => _whoplay; set => _whoplay = value; }
        public List<int> ChanceList { get => _chanceList; set => _chanceList = value; }
        public List<int> SocietyTreasure { get => _societyTreasure; set => _societyTreasure = value; }
        public TurnHistory History { get => _history; set => _history = value; }
        public static GameStatus Instance 
        {
            get 
            {
                return GameEngine.Engine.GameStatus;
            }
        }

        

        public GameStatus()
        {
            _players = new List<Player>();
            _boardFields = new List<Field>();
            _whoplay = EPlayerId.Bank;
        }
        /*

        public EPlayerId WhoPlay()
        {
            return Enum.Parse<EPlayerId>(_whoplayAsString);
        }

        */
        
        /// <summary>
        /// Dodaje niezbędne terytoria do listy z terytoriami
        /// </summary>
        public void InitBoard()
        {
            BoardFields.Clear();
            BoardFields.Add(new Field("Start", 0));
            BoardFields.Add(new StreetField("IiE", 1));
            BoardFields.Add(new Field("Kasa Społeczna", 2));
            BoardFields.Add(new StreetField("Zarządzenie", 3));
            BoardFields.Add(new Field("Podatek", 4));
            BoardFields.Add(new RailwayField("Akademik Babilon", 5));
            BoardFields.Add(new StreetField("cyberbezpieczeństwo", 6));
            BoardFields.Add(new Field("Szansa", 7));
            BoardFields.Add(new StreetField("Teleinformatyka", 8));
            BoardFields.Add(new StreetField("Elektronika", 9));
            BoardFields.Add(new Field("Kac", 10));
            BoardFields.Add(new StreetField("Inżynieria Akustyczna", 11));
            BoardFields.Add(new UtilityField("Browar Górniczo Hutniczy", 12));
            BoardFields.Add(new StreetField("AutomatykaPrzemyslowa i Robotyka", 13));
            BoardFields.Add(new StreetField("Mechanika i BudowaMaszyn", 14));
            BoardFields.Add(new RailwayField("Akademik Kapitol", 15));
            BoardFields.Add(new StreetField("Fizyka Medyczna", 16));
            BoardFields.Add(new Field("Szansa", 17));
            BoardFields.Add(new StreetField("Fizyka Techniczna", 18));
            BoardFields.Add(new StreetField("Informatyka Stosowana", 19));
            BoardFields.Add(new Field("Parking", 20));
            BoardFields.Add(new StreetField("Geodezja i Kartografia", 21));
            BoardFields.Add(new Field("Szansa", 22));
            BoardFields.Add(new StreetField("Geoinformacja", 23));
            BoardFields.Add(new StreetField("Inżynieria i Monitoring Środowiska", 24));
            BoardFields.Add(new RailwayField("Akademik Akropol", 25));
            BoardFields.Add(new StreetField("EdukacjaTechniczno Informatyczna", 26));
            BoardFields.Add(new StreetField("Inżynieria Obliczeniowa", 27));
            BoardFields.Add(new UtilityField("Klub Studio", 28));
            BoardFields.Add(new StreetField("Inżynieria Ciepła", 29));
            BoardFields.Add(new Field("Idź Na Kaca", 30));
            BoardFields.Add(new StreetField("Informatyka Społeczna", 31));
            BoardFields.Add(new StreetField("Kulturoznawstwo", 32));
            BoardFields.Add(new Field("Kasa Społeczna", 33));
            BoardFields.Add(new StreetField("Socjologia", 34));
            BoardFields.Add(new RailwayField("Akademik Olimp", 35));
            BoardFields.Add(new Field("Szansa", 36));
            BoardFields.Add(new StreetField("InżynieriaNaftowa i Klasowa", 37));
            BoardFields.Add(new Field("Podatek", 38));
            BoardFields.Add(new StreetField("Geoinżynieria i GórnictwoOtworowe", 39));
        }


       
        public int GetChanceCardAndPutLast()
        {
            int retVal = _chanceList[0];
            _chanceList.RemoveAt(0);
            _chanceList.Add(retVal);
            return retVal;
        }

        public int GetTreasureCardAndPutLast()
        {
            int retVal = _societyTreasure[0];
            _societyTreasure.RemoveAt(0);
            _societyTreasure.Add(retVal);
            return retVal;
        }

        /// <summary>
        /// Zapisuje stan rozgrywki do pliku XML
        /// </summary>
        /// <param name="filename">konieczne jest dodanie .xml</param>
        /// <param name="status">obecny stan gry</param>
        public static void SaveToFile(string filename, GameStatus status) 
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameStatus));
            TextWriter writer = new StreamWriter($"{filename}");
            serializer.Serialize(writer, status);
            writer.Close();
        }


        /// <summary>
        /// Wczytuje stan rozgrywki z pliku XML
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static GameStatus LoadfromFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameStatus));

            FileStream fs = new FileStream($"{filename}", FileMode.Open);
            GameStatus loadStatus = (GameStatus)serializer.Deserialize(fs);
            fs.Close();
            return loadStatus;
        }

        
        /// <summary>
        /// Inicjuje nową rozgrywkę, tworzy elementy na planszy, losuje losową kolejność kolekcji kart i uzupełnia listę graczy
        /// </summary>
        /// <param name="listOfPlayer"></param>
        public void InitiateNewGame(List<Player> listOfPlayer) 
        {
            InitBoard();
            MakeRandomChance();
            MakeRandomTreasureChest();
            //Inicjuje graczy i wrzuca do tablicy
            Players.Clear();
            foreach(Player player in listOfPlayer) 
            {
                Players.Add(player);
            }
            _whoplay = Players[0].PlayerId;
            _history = new TurnHistory();
            GameEngine.Engine.GameStatus = this;
        }


        private void MakeRandomChance() 
        {
            _chanceList = new List<int>();
            List<int> randomlist= new List<int>() {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14 };
            while (_chanceList.Count < 15) 
            {
                Random random = new Random();
                int randomnumber = random.Next(0,randomlist.Count);
                int numberToAdd = randomlist[randomnumber];
                _chanceList.Add(numberToAdd);
                randomlist.Remove(numberToAdd);
            }
        }
        private void MakeRandomTreasureChest()
        {
            _societyTreasure = new List<int>();
            List<int> randomlist = new List<int>() { 15,16,17,18,19,20,21,22,23,24,25,26,27,28,29 };
            while (_societyTreasure.Count < 15)
            {
                Random random = new Random();
                int randomnumber = random.Next(0, randomlist.Count);
                int numberToAdd = randomlist[randomnumber];
                _societyTreasure.Add(numberToAdd);
                randomlist.Remove(numberToAdd);
            }
        }

        public void PlayerListAdjustForNewGame(List<Player> AdjustingPlayer) 
        {
            Players.Clear();
            foreach(Player player in AdjustingPlayer) 
            {
                Players.Add(player);
            }
        }

        /// <summary>
        /// inicjuje statyczne dane do rozgrywki
        /// </summary>
        
        public void initStaticData()
        {
            ((StreetField)BoardFields[1]).Price = 60;
            ((StreetField)BoardFields[3]).Price = 60;
            ((PropertyField)BoardFields[5]).Price = 200;
            ((StreetField)BoardFields[6]).Price = 100;
            ((StreetField)BoardFields[8]).Price = 100;
            ((StreetField)BoardFields[9]).Price = 120;
            ((StreetField)BoardFields[11]).Price = 140;
            ((PropertyField)BoardFields[12]).Price = 140;
            ((StreetField)BoardFields[13]).Price = 140;
            ((StreetField)BoardFields[14]).Price = 150;
            ((PropertyField)BoardFields[15]).Price = 200;
            ((StreetField)BoardFields[16]).Price = 180;
            ((StreetField)BoardFields[18]).Price = 180;
            ((StreetField)BoardFields[19]).Price = 200;
            ((StreetField)BoardFields[21]).Price = 220;
            ((StreetField)BoardFields[23]).Price = 220;
            ((StreetField)BoardFields[24]).Price = 240;
            ((PropertyField)BoardFields[25]).Price = 200;
            ((StreetField)BoardFields[26]).Price = 260;
            ((StreetField)BoardFields[27]).Price = 260;
            ((PropertyField)BoardFields[28]).Price = 150;
            ((StreetField)BoardFields[29]).Price = 280;
            ((StreetField)BoardFields[31]).Price = 300;
            ((StreetField)BoardFields[32]).Price = 300;
            ((StreetField)BoardFields[34]).Price = 320;
            ((PropertyField)BoardFields[35]).Price = 200;
            ((StreetField)BoardFields[37]).Price = 350;
            ((StreetField)BoardFields[39]).Price = 400;
        }

        public List<Player> GetVisitors(int coordinates)
        {
            List<Player> list = new List<Player>();
            foreach(Player playeringame in Players) 
            {
                if (playeringame.Coordinates == coordinates) { list.Add(playeringame); }
            }
            return list;
        }


        public string GetFieldName(int coordinates) => BoardFields.Where(x=>x.Coordinates==coordinates).FirstOrDefault().Fieldname;

        public Field GetField(int coordinates) => BoardFields.Where(x => x.Coordinates == coordinates).First();


        public int GetNoOfHouse(int coordinates) => ((StreetField)(BoardFields.Where(x => x.Coordinates == coordinates).FirstOrDefault())).NoOfHouse;
        public void BuildHouse(int coordinates) 
        {
            ((StreetField)BoardFields[coordinates]).NoOfHouse += 1;

        }

        
        public void ChangeTurn() 
        {
            Player currentPlayer = GameEngine.CurrentPlayer;
            int idx = _players.IndexOf(currentPlayer);
            if (idx < _players.Count-1)
            {
                _whoplay = _players[idx + 1].PlayerId;
            }
            else
            {
                _whoplay = _players[0].PlayerId;
            }
            _history = new TurnHistory();
            Player newPlayer = GameEngine.CurrentPlayer;
            if (!newPlayer.IsActive) ChangeTurn();
            if (newPlayer.IsPrisoner())
            {
                newPlayer.TurnsToStayInPrison -= 1;
                if( !newPlayer.IsPrisoner() )
                {
                    GameEngine.Engine.AddAction(new InfoOnlyAction(null, "Kac wyleczony. Hulaj dusza... :)"));
                }
            }
            CheckWinner();
        }

        private void CheckWinner() 
        {
            int count = Players.Where(x => x.IsActive == true).Count();
            if (count == 1)
            {
                Player winner = Players.Where(x => x.IsActive == true).First();
                GameEngine.Engine.AddAction(new InfoOnlyAction(null, $"Gratulacje {winner.Name} wygrałeś gre"));
            }
        }
        

        public List<PropertyField> GetAllPropertiesOwnedBy(EPlayerId playerId) 
        {
            List<PropertyField> propertyFields= new List<PropertyField>();
   
            foreach(Field field in BoardFields) 
            {
                if (field is PropertyField)
                {
                    PropertyField pField = (PropertyField)field;
                    if (pField.Owner == playerId) { propertyFields.Add(pField); }
                }
            }
            return propertyFields;
        }

        public Player GetPlayer(EPlayerId playerId)
        {
            if (Players.Where(x => x.PlayerId == playerId).Count() > 0)
            {
                return Players.Where(x => x.PlayerId == playerId).First();
            }
            return null;
        }

        public Player GetCurrentPlayer() => GetPlayer(Whoplay);
    

        public int GetNoOfRailway(EPlayerId Owner) 
        {
            int sum = 0;
            for(int i = 5; i <= 35; i += 10) 
            {
                PropertyField Railway = (PropertyField)BoardFields[i];
                if (Railway.Owner == Owner) 
                {
                    sum++;
                }
            }

            return sum;
        }

        public int GetNoOfUtility(EPlayerId Owner)
        {
            int sum = 0;
            for (int i = 12; i <= 28; i += 16)
            {
                PropertyField UtilityField = (PropertyField)BoardFields[i];
                if (UtilityField.Owner == Owner)
                {
                    sum++;
                }
            }

            return sum;

        }

    }
}

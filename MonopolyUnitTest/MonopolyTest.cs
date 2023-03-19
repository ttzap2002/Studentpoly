using MonopolyData;
using MonopolyGui;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;



namespace MonopolyUnitTest
{
    public class MonopolyTest
    {
        [Fact]
        public void HowMuchAreFields()
        {
            // Arrange:
            int HowMuchIs = 0;
            GameStatus gs = new GameStatus();
            // Act:
            gs.InitBoard();
            foreach (var item in gs.BoardFields)
                HowMuchIs++;
            // Assert:
            Assert.AreEqual(HowMuchIs, 40);
        }

        [Fact]
        public void AreDifferent()
        {
            // Arrange:
            bool BulUszlachetnia = true;
            GameStatus gs = new GameStatus();
            int HowMuchIs;
            // Act:
            gs.InitBoard();
            foreach (var item in gs.BoardFields)
            {
                HowMuchIs = 0;
                foreach (var kitem in gs.BoardFields)
                {
                    if (kitem == item & HowMuchIs == 0)
                        HowMuchIs++;
                    else if (kitem == item)
                        BulUszlachetnia = false;
                }
            }
            // Assert:
            Assert.IsTrue(BulUszlachetnia);
        }

        [Fact]
        public void GetChanceCardAndPutLastTest()
        {
            // Arrange:
            GameStatus gs = new GameStatus();
            List<Player> pl = new List<Player>();
            int jakisNiewazne;
            bool boliMnie = true;
            // Act:
            pl.Add(new Player());
            gs.InitiateNewGame(pl);
            for (int i = 0; i < gs.ChanceList.Count; i++)
            {
                jakisNiewazne = gs.ChanceList[0];
                gs.GetChanceCardAndPutLast();
                if (gs.ChanceList[0] == jakisNiewazne)
                {
                    boliMnie = false;
                    break;
                }
            }
            // Assert:
            Assert.IsTrue(boliMnie);
        }

        [Fact]
        public void GetTreasureCardAndPutLastTest()
        {
            GameStatus gs = new GameStatus();
            List<Player> pl = new List<Player>();
            int jakisNiewazne;
            bool boliMnie = true;
            // Act:
            pl.Add(new Player());
            gs.InitiateNewGame(pl);
            for (int i = 0; i < gs.SocietyTreasure.Count; i++)
            {
                jakisNiewazne = gs.SocietyTreasure[0];
                gs.GetTreasureCardAndPutLast();
                if (gs.SocietyTreasure[0] == jakisNiewazne)
                {
                    boliMnie = false;
                    break;
                }
            }
            // Assert:
            Assert.IsTrue(boliMnie);
        }

        [Fact]
        public void GetVisitorsTest()
        {
            // Arrange:
            GameStatus gs = new GameStatus();
            List<Player> pl = new List<Player>();
            int numb = 6;
            // Act:
            for (int i = 0; i < numb; i++)
            {
                Player gamer = new Player();
                gamer.Coordinates = 10;
                pl.Add(gamer);
            }
            gs.InitiateNewGame(pl);
            List<Player> Answer = gs.GetVisitors(10);
            // Assert:
            Assert.AreEqual(Answer.Count, pl.Count);
        }

        [Fact]
        public void ChangeTurnTest()
        {
            // Arrange:
            GameStatus gs = new GameStatus();
            Player oryginal = new Player();
            Player anotherPerson = new Player();
            Player copy;
            List<Player> pl = new List<Player>();
            // Act:
            oryginal.PlayerId = EPlayerId.Car;
            copy = (Player)oryginal.Clone();
            pl.Add(oryginal);
            pl.Add(anotherPerson);
            gs.InitiateNewGame(pl);
            gs.ChangeTurn();
            // Assert:
            Assert.AreNotEqual(copy.PlayerId, gs.GetCurrentPlayer().PlayerId);
        }
    }

}
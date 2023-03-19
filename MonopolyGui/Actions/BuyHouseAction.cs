using MonopolyData;
using MonopolyLogic;

namespace MonopolyGui.Actions
{
    public class BuyHouseAction : GameAction
    {
        private StreetField st;

        public BuyHouseAction(StreetField st): base(null,$"Rozbuduj {st.Fieldname}")
        {
            this.st = st;
        }

        public override void Run()
        {
            st.NoOfHouse += 1;
            GameEngine.Engine.GameStatus.History.HousesBought += 1;
            GameEngine.CurrentPlayer.Wallet -= GameEngine.Engine.Calc.GetBuyHomePrice(st.Coordinates);
            DisplayShortTN($"Rozbudowałeś {st.Fieldname}");
            RefreshScreen();
        }
    }
}
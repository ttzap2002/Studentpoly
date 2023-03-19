using MonopolyData;
using MonopolyLogic;

namespace MonopolyGui.Actions
{
    public class SellHouseAction : GameAction
    {
        private StreetField streetField;

        public SellHouseAction(StreetField streetField) : base(null, $"Redukuj wyposażenie {streetField.Fieldname}")
        {
            this.streetField = streetField;
        }

        public override void Run()
        {
            streetField.NoOfHouse -= 1;
            GameEngine.CurrentPlayer.Wallet += GameEngine.Engine.Calc.GetSellHomePrice(streetField.Coordinates);
            DisplayShortTN($"Zredukowałeś {streetField.Fieldname}");
            RefreshScreen();
        }
    }
}
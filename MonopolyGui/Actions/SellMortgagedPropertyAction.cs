using MonopolyData;
using MonopolyLogic;

namespace MonopolyGui.Actions
{
    public class SellMortgagedPropertyAction : GameAction
    {
        private PropertyField propertyField;

        public SellMortgagedPropertyAction(PropertyField propertyField): base(null, $"Sprzedaj zastawioną nieruchomość: {propertyField.Fieldname}")
        {
            this.propertyField = propertyField;
        }

        public override void Run()
        {
            propertyField.IsMortgage = false;
            propertyField.Owner = EPlayerId.Bank;
            GameEngine.CurrentPlayer.Wallet += (int)(propertyField.Price / 4);
            DisplayShortTN($"Sprzedałeś nieruchomość {propertyField.Fieldname}");
            RefreshScreen();
        }
    }
}
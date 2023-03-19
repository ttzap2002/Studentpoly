using MonopolyData;
using MonopolyLogic;

namespace MonopolyGui.Actions
{
    internal class MortgageAction : GameAction
    {
        private PropertyField propertyField;

        public MortgageAction(PropertyField propertyField) : base(null, $"Zastaw {propertyField.Fieldname}")
        {
            this.propertyField = propertyField;
        }

        public override void Run()
        {
            propertyField.IsMortgage = true;
            GameEngine.CurrentPlayer.Wallet += propertyField.Price / 2;
            DisplayShortTN($"Zastawiłeś nieruchomość {propertyField.Fieldname}");
            RefreshScreen();
        }

    }
}
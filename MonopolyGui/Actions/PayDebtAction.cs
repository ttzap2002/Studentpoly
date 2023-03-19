using MonopolyData;
using MonopolyLogic;

namespace MonopolyGui.Actions
{
    public class PayDebtAction : GameAction
    {
        private PropertyField propertyField;
        private int toPay;

        public PayDebtAction(PropertyField propertyField, int toPay): base(null, 
            $"Spłać hipotekę {propertyField.Fieldname} - {toPay} zł")
        {
            this.propertyField = propertyField;
            this.toPay = toPay;
        }

        public override void Run()
        {
            propertyField.IsMortgage = false;
            GameEngine.Engine.GameStatus.GetCurrentPlayer().Wallet -= toPay;
            DisplayShortTN($"Hipoteka na {propertyField.Fieldname} spłacona!");
            RefreshScreen();
        }
    }
}
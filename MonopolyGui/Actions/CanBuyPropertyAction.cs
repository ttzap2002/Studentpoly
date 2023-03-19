using MonopolyData;
using MonopolyLogic;

namespace MonopolyGui.Actions
{
    internal class CanBuyPropertyAction : GameAction
    {
        private PropertyField thisPropertyField;

        public CanBuyPropertyAction(PropertyField thisPropertyField): base(null,$"Kup {thisPropertyField.Fieldname}")
        {
            this.thisPropertyField = thisPropertyField;
        }

        public override void Run()
        {
            Player p = GameEngine.Engine.GameStatus.GetCurrentPlayer();
            if(p.Wallet>=thisPropertyField.Price)
            {
                thisPropertyField.Owner = p.PlayerId;
                p.Wallet -= thisPropertyField.Price;
                MainWindow.PlaySound("kasa");
                DisplayTN($"Kupiłeś {thisPropertyField.Fieldname}");
                RefreshScreen();
            } 
            else
            {
                DisplayTN("Nie masz wystarczająco dużo pieniędzy. Może coś zastawisz, sprzedasz?");
            }
        }
    }
}
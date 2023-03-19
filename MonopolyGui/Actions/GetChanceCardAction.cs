using MonopolyLogic;

namespace MonopolyGui.Actions
{
    public class GetChanceCardAction : GameAction
    {
        public GetChanceCardAction() : base(null, "Pobierasz kartę szansy")
        {
        }

        public override void Run()
        {
            DisplayShortTN();
            int cardId = GameEngine.Engine.GameStatus.GetChanceCardAndPutLast();
            GameEngine.Engine.AddAction(GameEngine.Engine.CardContainer.GetCard(cardId));
        }
    }
}
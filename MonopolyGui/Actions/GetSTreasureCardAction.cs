using MonopolyLogic;

namespace MonopolyGui.Actions
{
    public class GetSTreasureCardAction : GameAction
    {
        public GetSTreasureCardAction() : base(null, "Pobierasz kartę Kasy Społecznej")
        {
        }

        public override void Run()
        {
            DisplayShortTN();
            int cardId = GameEngine.Engine.GameStatus.GetTreasureCardAndPutLast();
            GameEngine.Engine.AddAction(GameEngine.Engine.CardContainer.GetCard(cardId));
        }
    }
}
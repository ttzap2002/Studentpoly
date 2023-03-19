using MonopolyData;
using MonopolyLogic;

namespace MonopolyGui.Actions
{
    public class VisitPropertyAction : GameAction
    {
        public VisitPropertyAction() : base(null, null)
        {
        }

        public override void Run()
        {
            int coordinate = GameEngine.Engine.GameStatus.GetCurrentPlayer().Coordinates;
            PropertyField thisPropField = (PropertyField)GameEngine.Engine.GameStatus.BoardFields[coordinate];
            DisplayTN($"Odwiedziles {thisPropField.Fieldname}");
            Player currentPlayer = GameEngine.Engine.GameStatus.GetCurrentPlayer();


            if (thisPropField.Owner == EPlayerId.Bank)
            {
                // opis propery
                DisplayTN($"Możesz kupić {thisPropField.Fieldname} cena zakupu {thisPropField.Price}");
            }
            else if (thisPropField.Owner != currentPlayer.PlayerId)
            {
                // sprawdz czy wlasciciel w wiezieniu i jesli tak to tylko napi
                Player propertyOwner = GameEngine.Engine.GameStatus.GetPlayer(thisPropField.Owner);
                int charge = GameEngine.Engine.Calc.GetFee(coordinate, currentPlayer.PlayerId);
                if (propertyOwner.TurnsToStayInPrison > 0)
                {
                    DisplayTN($"Właścieciel {propertyOwner.Name} leczy kaca i nie przyjmie czynszu w tym stanie");
                }
                // sprawdz czy property zastawione i jestli tak to tylko napis
                else if (thisPropField.IsMortgage)
                {
                    DisplayTN($"Własność zastawiona - brak opłat ");
                }
                else
                {
                    // Sprawdz ile do zaplaty.  Jesli mamy kase to placimy natychmiast
                    GameEngine.Engine.AddAction(new PlayerPaysToPlayerAction(null, $"Płacisz {charge} graczowi {propertyOwner.Name} za {thisPropField.Fieldname}", propertyOwner.PlayerId, charge));
                }
            }

        }
    }
}
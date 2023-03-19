using MonopolyData;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace MonopolyGui
{
    public class PlayerInfoOnScreen
    {
        Canvas infocanvas;
        EPlayerId playerId;   
        
        public static string GetURIForPlayer(EPlayerId id)
        {
            string path = Environment.CurrentDirectory;
            if (id == EPlayerId.Canoon) return $@"{path}\Canoon.png";
            if (id == EPlayerId.Car) return $@"{path}\Car.png";
            if (id == EPlayerId.Iron) return $@"{path}\Iron.png";
            if (id == EPlayerId.Cat) return $@"{path}\Cat.png";
            if (id == EPlayerId.Dog) return $@"{path}\Dog.png";
            if (id == EPlayerId.Elephant) return $@"{path}\Slon.png";
            if (id == EPlayerId.Bank) return $@"{path}\Bank.png";
            return null;
            
        }

        public PlayerInfoOnScreen(Canvas infocanvas, EPlayerId playerId)
        {
            Infocanvas = infocanvas;
            this.playerId = playerId;
        }

        public Canvas Infocanvas { get => infocanvas; set => infocanvas = value; }
        public EPlayerId PlayerId { get => playerId;}

        public Label NameLabel { get => ((Label)infocanvas.Children[0]); }
        public Label PositionLabel { get => ((Label)infocanvas.Children[3]); }
        public Label CashLabel { get => ((Label)infocanvas.Children[4]); }
        
        public void RefreshPlayerInfoOnScreen() //Dynamic data
        {
            Player logicalPlayer = GameStatus.Instance.GetPlayer(playerId);
            if (logicalPlayer != null)
            {
                PositionLabel.Content = GameStatus.Instance.GetField(logicalPlayer.Coordinates).Fieldname;
                CashLabel.Content = "Kasa:\n\n" + logicalPlayer.Wallet;
                if (PlayerId == GameStatus.Instance.Whoplay)
                {
                    NameLabel.FontSize = 16;
                } else
                {
                    NameLabel.FontSize = 12;
                }
            }
            else
            {
                //TODO make the box inactive
            }
        }

        public void RefreshProperty() 
        {
            ((ListBox)infocanvas.Children[5]).Items.Clear();
            Player logicalPlayer = GameStatus.Instance.GetPlayer(playerId);

            if (logicalPlayer != null)
            {

                List<PropertyField> myPropertyFields = GameStatus.Instance.GetAllPropertiesOwnedBy(logicalPlayer.PlayerId);
                foreach (PropertyField item in myPropertyFields)
                {
                    ((ListBox)infocanvas.Children[5]).Items.Add(item.Fieldname+" czy za stawiony "+item.IsMortgage);

                }
                if (logicalPlayer.ExitPrisonCards > 0)
                {
                    ((ListBox)infocanvas.Children[5]).Items.Add($"Lek na kaca {logicalPlayer.ExitPrisonCards}");
                }
            }
        }






    }
}

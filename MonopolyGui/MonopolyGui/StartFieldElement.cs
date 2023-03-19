using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using MonopolyData;


namespace MonopolyGui
{
    public class StartFieldElement :FieldScreenElement
    {
        

       
        public StartFieldElement(Canvas canvasfield,int fieldID, Location orientation) :base(canvasfield,fieldID,orientation)
        {
            Canvasfield = canvasfield;
            Canvasfield.Height = 115;
            Canvasfield.Width = 115;
       
        }

       
        public void AddPlayerOnStart() 
        {
            GameStatus game = GameStatus.Instance;
            List<Player> listofplayeronfield = game.GetVisitors(fieldId);

            int playerplacement = 0;
            foreach (Player player in listofplayeronfield)
            {
                Image myimage = new Image();
                myimage.Width = 15;
                myimage.Height = 15;
                myimage.VerticalAlignment = VerticalAlignment.Top;
                myimage.HorizontalAlignment = HorizontalAlignment.Left;

                BitmapImage bmpmyimage = new BitmapImage();
                Canvasfield.Children.Add(myimage);

                string bitmapFile = PlayerInfoOnScreen.GetURIForPlayer(player.PlayerId);

                bmpmyimage.BeginInit();
                bmpmyimage.UriSource = new Uri(bitmapFile, UriKind.RelativeOrAbsolute);
                bmpmyimage.EndInit();
      
                myimage.Source= bmpmyimage;
                /*
                if (playerplacement == 0)
                {
                    Canvas.SetLeft(myimage, 10);
                    Canvas.SetTop(myimage, 12);
                }

                else if (playerplacement == 1)
                {
                    Canvas.SetLeft(myimage, 10);
                    Canvas.SetTop(myimage, 42);
                }

                else if (playerplacement == 2)
                {
                    Canvas.SetLeft(myimage, 40);
                    Canvas.SetTop(myimage, 12);
                }

                else if (playerplacement == 3)
                {
                    Canvas.SetLeft(myimage, 40);
                    Canvas.SetTop(myimage, 42);
                }

                else if (playerplacement == 4)
                {
                    Canvas.SetLeft(myimage, 70);
                    Canvas.SetTop(myimage, 12);
                }

                else if (playerplacement == 5)
                {
                    Canvas.SetLeft(myimage, 70);
                    Canvas.SetTop(myimage, 42);
                }
                */

                playerplacement++;
        
               
            }
        }

    

     

      
    }
}

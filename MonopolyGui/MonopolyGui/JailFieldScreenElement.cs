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
    public class JailFieldScreenElement :FieldScreenElement
    {

        public JailFieldScreenElement(Canvas canvasfield,int fieldId,Location orientation) :base(canvasfield,fieldId,orientation)
        {
            Canvasfield = canvasfield;
            Canvasfield.Height = 95;
            Canvasfield.Width = 95;
            
        }


        private void AddPlayerOnScreen()
        {
            GameStatus game = GameStatus.Instance;
            List<Player> listofplayeronfield = game.GetVisitors(fieldId);
            int numberofplayeroffield = 0;
            int iterationforprisoner = 0;
            Canvasfield.Height = 95;
            Canvasfield.Width = 95;


            foreach (Player player in listofplayeronfield)
            {
                Image myimage = new Image();
                myimage.VerticalAlignment = VerticalAlignment.Top;
                myimage.HorizontalAlignment = HorizontalAlignment.Left;
                myimage.Height = 30;
                myimage.Width = 30;

                BitmapImage bmpmyimage = new BitmapImage();
                Canvasfield.Children.Add(myimage);


                bmpmyimage.BeginInit();
                bmpmyimage.UriSource = new Uri(PlayerInfoOnScreen.GetURIForPlayer(player.PlayerId), UriKind.RelativeOrAbsolute);
                bmpmyimage.EndInit();

                myimage.Source = bmpmyimage;



                if (player.TurnsToStayInPrison == 0)
                {
                    if (numberofplayeroffield == 0)
                    {
                        Canvas.SetLeft(myimage, 60);
                        Canvas.SetTop(myimage, 60);
                    }

                    else if (numberofplayeroffield == 1)
                    {
                        Canvas.SetLeft(myimage, 30);
                        Canvas.SetTop(myimage, 60);
                    }

                    else if (numberofplayeroffield == 2)
                    {
                        Canvas.SetLeft(myimage, 35);
                        Canvas.SetTop(myimage, 95);
                    }

                    else if (numberofplayeroffield == 3)
                    {
                        Canvas.SetLeft(myimage, 5);
                        Canvas.SetTop(myimage, 95);
                    }

                    else if (numberofplayeroffield == 4)
                    {
                        Canvas.SetLeft(myimage, 5);
                        Canvas.SetTop(myimage, 65);
                    }

                    else if (numberofplayeroffield == 5)
                    {
                        Canvas.SetLeft(myimage, 5);
                        Canvas.SetTop(myimage, 35);
                    }
                }

                else
                {
                    Canvas.SetLeft(myimage, 60 + iterationforprisoner);
                    Canvas.SetTop(myimage, 20 + iterationforprisoner);
                    iterationforprisoner += 10;
                }


                numberofplayeroffield++;


            }
             
                        
            
        }


        private void ClearAllImages()
        {
            Canvasfield.Children.Clear();
        }

        public override void Refresh()
        {
            ClearAllImages();
            AddPlayerOnScreen();
        }




    }
}

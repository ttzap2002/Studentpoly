using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MonopolyData;


namespace MonopolyGui
{
    public class StreetFieldScreenElement : FieldScreenElement
    {
        public StreetFieldScreenElement(Canvas canvasfield, int fieldID, Location orientation) : base(canvasfield, fieldID, orientation)
        {

        }






        private TransformedBitmap RotateBuilding(int angle, BitmapImage bmpimage) 
        {
            TransformedBitmap transformBmp = new TransformedBitmap();

            transformBmp.BeginInit();

            transformBmp.Source = bmpimage;

            RotateTransform transform = new RotateTransform(angle);

            transformBmp.Transform = transform;

            transformBmp.EndInit();

            return transformBmp;
        }


        private Image InitializeBuilding(bool isHouse,Location location)
        {
            string path = Environment.CurrentDirectory;
            Image myBuilding = new Image();
            
            myBuilding.Height = 15;
            myBuilding.Width = 15;
            BitmapImage imageOfBuilding = new BitmapImage();
            imageOfBuilding.BeginInit();
            if (isHouse)
            {
                imageOfBuilding.UriSource = new Uri(@$"{path}\House.png", UriKind.RelativeOrAbsolute);
            }
            else
            {
                imageOfBuilding.UriSource = new Uri(@$"{path}\Hotel.png", UriKind.RelativeOrAbsolute);
            }
            imageOfBuilding.EndInit();
            if (location == Location.South) 
            {
                myBuilding.Source = imageOfBuilding;
            }

            else if (location == Location.West)
            {
                TransformedBitmap rotateimage = RotateBuilding(90, imageOfBuilding);
                myBuilding.Source = rotateimage;
            }
            else if (location == Location.North) 
            {
                TransformedBitmap rotateimage = RotateBuilding(180, imageOfBuilding);
                myBuilding.Source = rotateimage;
            }
            else if (location == Location.East)
            {
                TransformedBitmap rotateimage = RotateBuilding(270, imageOfBuilding);
                myBuilding.Source = rotateimage;
            }

            return myBuilding;
        }


        private void DrawBulding()
        {
            StreetField streetField = (StreetField) GameStatus.Instance.GetField(fieldId);
            streetField.NoOfHouse = ((StreetField)GameStatus.Instance.BoardFields[streetField.Coordinates]).NoOfHouse;
            if (Orientation == Location.South)
            {
                if (streetField.NoOfHouse < 5 && streetField.NoOfHouse > 0)
                {
                    int LeftAdding = 0;
                    for (int i = 0; i < streetField.NoOfHouse; i++)
                    {
                        Image house = InitializeBuilding(true,Orientation);
                        Canvasfield.Children.Add(house);
                        Canvas.SetLeft(house, LeftAdding);
                        Canvas.SetTop(house, 0);
                        LeftAdding += 17;
                    }
                }
                else if (streetField.NoOfHouse == 5)
                {
                    Image hotel = InitializeBuilding(false,Orientation);
                    Canvasfield.Children.Add(hotel);
                    Canvas.SetLeft(hotel, 25);
                    Canvas.SetTop(hotel, 0);
                }
            }

            else if (Orientation == Location.West)
            {
                if (streetField.NoOfHouse < 5 && streetField.NoOfHouse > 0)
                {
                    int TopAdding = 0;
                    for (int i = 0; i < streetField.NoOfHouse; i++)
                    {
                        Image house = InitializeBuilding(true, Orientation);
                        Canvasfield.Children.Add(house);
                        Canvas.SetLeft(house, 100);
                        Canvas.SetTop(house, TopAdding);
                        TopAdding += 18;
                    }
                }
                else if (streetField.NoOfHouse == 5)
                {
                    Image hotel = InitializeBuilding(false, Orientation);
                    Canvasfield.Children.Add(hotel);
                    Canvas.SetLeft(hotel, 80);
                    Canvas.SetTop(hotel, 25);
                }

            }



            else if (Orientation == Location.North)
            {
                if (streetField.NoOfHouse < 5 && streetField.NoOfHouse > 0)
                {
                    int LeftAdding = 0;
                    for (int i = 0; i < streetField.NoOfHouse; i++)
                    {
                        Image house = InitializeBuilding(true, Orientation);
                        Canvasfield.Children.Add(house);
                        Canvas.SetLeft(house, LeftAdding);
                        Canvas.SetTop(house, 95);
                        LeftAdding += 18;
                    }
                }
                else if (streetField.NoOfHouse == 5)
                {
                    Image hotel = InitializeBuilding(false, Orientation);
                    Canvasfield.Children.Add(hotel);
                    Canvas.SetLeft(hotel, 30);
                    Canvas.SetTop(hotel, 95);
                }

            }



            else if (Orientation == Location.East)
            {
                if (streetField.NoOfHouse < 5 && streetField.NoOfHouse > 0)
                {
                    int TopAdding = 0;
                    for (int i = 0; i < streetField.NoOfHouse; i++)
                    {
                        Image house = InitializeBuilding(true, Orientation);
                        Canvasfield.Children.Add(house);
                        Canvas.SetLeft(house, 0);
                        Canvas.SetTop(house, TopAdding);
                        TopAdding += 18;
                    }
                }
                else if (streetField.NoOfHouse == 5)
                {
                    Image hotel = InitializeBuilding(false, Orientation);
                    Canvasfield.Children.Add(hotel);
                    Canvas.SetLeft(hotel, 0);
                    Canvas.SetTop(hotel, 25);
                }

            }





        }


        public override void Refresh()
        {
            base.Refresh();
            DrawBulding();
        }


   





    }
}


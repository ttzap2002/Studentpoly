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
using MonopolyGui;

namespace MonopolyGui
{
    public enum Location 
    {
        South,
        West,
        North,
        East
    }
    public class FieldScreenElement : IRefreshField
    {
        Canvas canvasfield;
        Location orientation;
        protected int fieldId;

        public FieldScreenElement(Canvas canvasfield,int id,Location orientation)
        {
            Canvasfield = canvasfield;
            Orientation = orientation;
            fieldId = id;
            SettingsPropertyToCanvas();
        }

        public Canvas Canvasfield { get => canvasfield; set => canvasfield = value; }
        //public Field Logicalfield { get => logicalfield; set => logicalfield = value; }
        public Location Orientation { get => orientation; set => orientation = value; }

        public Canvas getCanvas() { return canvasfield; }

        private void SettingsPropertyToCanvas()
        {
            Canvasfield.HorizontalAlignment= HorizontalAlignment.Left;
            Canvasfield.VerticalAlignment= VerticalAlignment.Top;
            if (Orientation == Location.North || Orientation == Location.South)
            {
                Canvasfield.Height = 114;
                Canvasfield.Width = 72;

            }

            else if (Orientation == Location.East || Orientation == Location.West)
            {
                Canvasfield.Width = 114;
                Canvasfield.Height = 72;
            }
           
        }


        protected void AddPlayerOnScreen()
        {
            GameStatus game = GameStatus.Instance;
            List<Player> listofplayeronfield = game.GetVisitors(fieldId);
            int playerplacement = 0;
            ScaleTransform scaletransform = new ScaleTransform();
            scaletransform.ScaleX = -1;

            foreach (Player player in listofplayeronfield)
            {
                if (player.IsActive)
                {
                    Image myimage = new Image();

                    BitmapImage bmpmyimage = new BitmapImage();
                    Canvasfield.Children.Add(myimage);

                    string bitmapFile = PlayerInfoOnScreen.GetURIForPlayer(player.PlayerId);

                    bmpmyimage.BeginInit();
                    bmpmyimage.UriSource = new Uri(bitmapFile, UriKind.RelativeOrAbsolute);
                    bmpmyimage.EndInit();
                    ImageAdjust(Orientation, myimage, bmpmyimage, playerplacement, scaletransform);
                    playerplacement++;
                }
            }
        }

        void ImageAdjust(Location imagelocation, Image myimage, BitmapImage bmpmyimage, int iteration, ScaleTransform scaletransform)
        {
            myimage.Height = 30;
            myimage.Width = 30;
            if (Orientation == Location.South)
            {
                TransformImageSouth(myimage, bmpmyimage, iteration);
            }
            else if (Orientation == Location.West)
            {
                TranformImageWest(myimage, bmpmyimage, scaletransform, iteration);
            }
            else if (Orientation == Location.North)
            {
                TransformImageNorth(myimage, bmpmyimage, scaletransform, iteration);

            }
            else if (Orientation == Location.East)
            {
                TranformImageEast(myimage, bmpmyimage, scaletransform, iteration);
            }
        }



        void TransformImageSouth(Image image_to_transform, BitmapImage bitmapImage, int playerplacement)
        {
            image_to_transform.Source = new BitmapImage(bitmapImage.UriSource);
            if (playerplacement == 0)
            {
                Canvas.SetLeft(image_to_transform, 4);
                Canvas.SetTop(image_to_transform, 32);
            }

            else if (playerplacement == 1)
            {
                Canvas.SetLeft(image_to_transform, 44);
                Canvas.SetTop(image_to_transform, 62);
            }

            else if (playerplacement == 2)
            {
                Canvas.SetLeft(image_to_transform, 44);
                Canvas.SetTop(image_to_transform, 32);
            }

            else if (playerplacement == 3)
            {
                Canvas.SetLeft(image_to_transform, 4);
                Canvas.SetTop(image_to_transform, 62);
            }

            else if (playerplacement == 4)
            {
                Canvas.SetLeft(image_to_transform, 24);
                Canvas.SetTop(image_to_transform, 32);
            }

            else if (playerplacement == 5)
            {
                Canvas.SetLeft(image_to_transform, 44);
                Canvas.SetTop(image_to_transform, 62);
            }

        }


        void TranformImageWest(Image image_to_transform, BitmapImage bitmapImage, ScaleTransform scaletransform, int playerplacement)
        {
            TransformedBitmap transformBmp = new TransformedBitmap();

            transformBmp.BeginInit();

            transformBmp.Source = bitmapImage;

            RotateTransform transform = new RotateTransform(90);

            transformBmp.Transform = transform;

            transformBmp.EndInit();

            image_to_transform.Source = transformBmp;

            image_to_transform.RenderTransform = scaletransform;


            if (playerplacement == 0)
            {
                Canvas.SetLeft(image_to_transform, 82);
                Canvas.SetTop(image_to_transform, 4);
            }

            else if (playerplacement == 1)
            {
                Canvas.SetLeft(image_to_transform, 42);
                Canvas.SetTop(image_to_transform, 44);
            }

            else if (playerplacement == 2)
            {
                Canvas.SetLeft(image_to_transform, 82);
                Canvas.SetTop(image_to_transform, 44);
            }

            else if (playerplacement == 3)
            { 
                Canvas.SetLeft(image_to_transform, 42);
                Canvas.SetTop(image_to_transform, 4);
            }

            else if (playerplacement == 4)
            {
                Canvas.SetLeft(image_to_transform, 82);
                Canvas.SetTop(image_to_transform, 24);
            }

            else if (playerplacement == 5)
            {
                Canvas.SetLeft(image_to_transform, 42);
                Canvas.SetTop(image_to_transform, 24);
            }

        }

        void TransformImageNorth(Image image_to_transform, BitmapImage bitmapImage, ScaleTransform scaletranform, int playerplacement)
        {
            image_to_transform.Source = bitmapImage;
            image_to_transform.RenderTransform = scaletranform;



            if (playerplacement == 0)
            {
                Canvas.SetLeft(image_to_transform, 68);
                Canvas.SetTop(image_to_transform, 52);
            }

            else if (playerplacement == 1)
            {
                Canvas.SetLeft(image_to_transform, 30);
                Canvas.SetTop(image_to_transform, 22);
            }

            else if (playerplacement == 2)
            {
                Canvas.SetLeft(image_to_transform, 30);
                Canvas.SetTop(image_to_transform, 52);
            }

            else if (playerplacement == 3)
            {
                Canvas.SetLeft(image_to_transform, 68);
                Canvas.SetTop(image_to_transform, 22);
            }

            else if (playerplacement == 4)
            {
                Canvas.SetLeft(image_to_transform, 49);
                Canvas.SetTop(image_to_transform, 52);
            }

            else if (playerplacement == 5)
            {
                Canvas.SetLeft(image_to_transform, 49);
                Canvas.SetTop(image_to_transform, 22);
            }

        }

        void TranformImageEast(Image image_to_transform, BitmapImage bitmapImage, ScaleTransform scaletransform, int playerplacement)
        {
            TransformedBitmap transformBmp = new TransformedBitmap();

            transformBmp.BeginInit();

            transformBmp.Source = bitmapImage;

            RotateTransform transform = new RotateTransform(270);

            transformBmp.Transform = transform;

            transformBmp.EndInit();

            image_to_transform.Source = transformBmp;

            image_to_transform.RenderTransform = scaletransform;


            if (playerplacement == 0)
            {
                Canvas.SetLeft(image_to_transform, 54);
                Canvas.SetTop(image_to_transform, 44);
            }

            else if (playerplacement == 1)
            {
                Canvas.SetLeft(image_to_transform, 84);
                Canvas.SetTop(image_to_transform, 6);
            }

            else if (playerplacement == 2)
            {
                Canvas.SetLeft(image_to_transform, 84);
                Canvas.SetTop(image_to_transform, 6);
            }

            else if (playerplacement == 3)
            {
                Canvas.SetLeft(image_to_transform, 84);
                Canvas.SetTop(image_to_transform, 44);
            }

            else if (playerplacement == 4)
            {
                Canvas.SetLeft(image_to_transform, 32);
                Canvas.SetTop(image_to_transform, 28);
            }

            else if (playerplacement == 5)
            {
                Canvas.SetLeft(image_to_transform, 52);
                Canvas.SetTop(image_to_transform, 48);
            }

        }

        private void ClearAllImages() 
        {
            Canvasfield.Children.Clear();
        }

        public virtual void Refresh()
        {
            ClearAllImages();
            AddPlayerOnScreen();
        }

        public void SetMargin(double left, double right, double top, double down)
        {
            Canvasfield.Margin = new Thickness(left, right, top, down);
        }
    }
}

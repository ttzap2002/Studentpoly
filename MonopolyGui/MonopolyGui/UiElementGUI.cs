using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
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

  

namespace MonopolyGui
{
    public static class UiElementGUI
    {
        //zostanie dodana w nowej wersji
        public static void GenerateAnimation(string urisourcefirstimage,Grid mygrid ,string urisourcesecondimage, ActionPanel action) 
        {
            Canvas helpCanvas= new Canvas();
            helpCanvas.Height= 200;
            helpCanvas.Width= 400;
            helpCanvas.Margin= new Thickness(400,400,0,0);
            helpCanvas.HorizontalAlignment= HorizontalAlignment.Left;
            helpCanvas.VerticalAlignment= VerticalAlignment.Top;



            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(urisourcefirstimage, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();

            BitmapImage bitmapImage2 = new BitmapImage();
            bitmapImage2.BeginInit();
            bitmapImage2.UriSource = new Uri(urisourcesecondimage, UriKind.RelativeOrAbsolute);
            bitmapImage2.EndInit();
            action.ChangeVisibility();
            Image firstImage = new Image();
            firstImage.Source = bitmapImage;
            firstImage.Width = bitmapImage2.Width;
            firstImage.Height = bitmapImage2.Height;
            firstImage.HorizontalAlignment = HorizontalAlignment.Left;
            firstImage.VerticalAlignment = VerticalAlignment.Top;

            Image secondImage = new Image();
            secondImage.Source = bitmapImage2;
            secondImage.Width = bitmapImage2.Width;
            secondImage.Height = bitmapImage2.Height;



            helpCanvas.Children.Add(firstImage);
            helpCanvas.Children.Add(secondImage);

            Canvas.SetLeft(firstImage, 20);
            Canvas.SetTop(firstImage, 50);

            Canvas.SetLeft(secondImage, 100);
            Canvas.SetTop(secondImage, 50);


            mygrid.Children.Add(helpCanvas);

            Thread.Sleep(5000);
            //mygrid.Children.Remove(helpCanvas);


        }
    }
}

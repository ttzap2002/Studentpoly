using MonopolyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MonopolyLogic;
using MonopolyGui.Actions;

namespace MonopolyGui
{
    public class DynamicButton : Button
    {
        
        string _urisourcetoicon;
        GameAction _action;


        public DynamicButton( GameAction a )
        {
            this.AddText(a.Actionlabel);
            this._action= a;
            this.Width = 605;
            this.Height = 55;
            this.Click += (s, e) => { this.OnButtonPressed(); };
            // TODO set color here
        }
        //brak czasu
        public void CreateProopertyToButton(string textAction)
        {
            StackPanel myStackPanel = new StackPanel();
           
            BitmapImage bitmapImage= new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource=new Uri(_urisourcetoicon,UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            Image myimage = new Image();
            myimage.Source=bitmapImage;
            myimage.Height = 20;
            myimage.Width = 20;
            myimage.Margin = new Thickness(20, 0, 0, 0);
            
            TextBox mytextbox = new TextBox();
            mytextbox.Text=textAction;
            myStackPanel.Children.Add(myimage);
            myStackPanel.Children.Add(mytextbox);

            this.Content = myStackPanel;
        }

        public void OnButtonPressed()
        {
            // schowaj panel z przyciskami
            MainWindow.Instance.ListBoxWithAction.Visibility=Visibility.Collapsed;
            // dodaj akcje do GameEngine
            (GameEngine.Engine).AddAction(_action);
            // wywolaj GameEngine.runGame()
            (GameEngine.Engine).RunGame();
        }

      

        
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MonopolyData;
using MonopolyGui;
using MonopolyLogic;


namespace MonopolyGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow _instance;

        BoardPanel _myboard;
        InfoPanel _myinfopanel;
        ActionPanel _actionPanel;
        GameEngine _engine;
        static private MediaPlayer myPlayer = new MediaPlayer();

        //string t1; ForEasierTestingGui
        //string t2; ForEasierTestingGui

        string mysong;

        public ActionPanel ActionPanel { get => _actionPanel; set => _actionPanel = value; }
        public static MainWindow Instance { get => _instance;}

        public MainWindow()
        {
            _engine = GameEngine.Engine;
            InitializeComponent();
            InitializeBoard();
            InitializePlayerInfoPanel();

            mysong = "canoninD";
            PlayMusic(mysong, true);

            /*
            actionPanel = new ActionPanel(ListBoxWithAction);
   
            for(int i=0; i<5; i++) 
            {
                Button button= new Button();
                DynamicButton mybutton = new DynamicButton(@"C:\Users\zapar\source\repos\NewRepo\Image\House.png");
                mybutton.CreateProopertyToButton("To jest moja akcja");
                actionPanel.AddItemToListBox(mybutton);
            }
            actionPanel.SetMarginForButton();
            Label actionlabeL = new Label();
            actionlabeL.Content = $"Wszyskie możliwe akcje do wykonania dla gracza {GameStatus.Instance.GetWhoplay().Name}";
            actionlabeL.FontSize= 20;
            actionPanel.Actionlistbox.Items.Insert(0, actionlabeL);
            */
            _actionPanel = new ActionPanel(ListBoxWithAction);
            _instance = this;
        }

        private void IsActivePlayerInfoAdjust(bool isTrue,PlayerInfoOnScreen playerInfo) 
        {
            if (!isTrue) 
            {
                playerInfo.Infocanvas.Visibility=Visibility.Collapsed;
            }
        }

        private void GroupedCheckIsActivePlayerInfoAdjust(GameStatus currentGameStatus) 
        {

            for(int i = 0; i <= 5; i++) 
            {
                IsActivePlayerInfoAdjust(currentGameStatus.Players.Contains(currentGameStatus.GetPlayer(_myinfopanel.Playerinfo[i].PlayerId)), _myinfopanel.Playerinfo[i]);
            }
        }


        private void InitializePlayerInfoPanel ()
        {
            _myinfopanel = new InfoPanel(GUIInfoPanel);
            GameStatus currentGameStatus = _engine.GameStatus;

            PlayerInfoOnScreen player1 = new PlayerInfoOnScreen(CanvasPlayerone,EPlayerId.Elephant);
            ActualPosition.Content = "Aktualna Pozycja";
            Pocket.Content = "Kasa: ";
            CurrentPosition.Content = "Start";
            PlayerName.Content = "Słoń";
            _myinfopanel.AddPlayerInfo(player1);
  

            PlayerInfoOnScreen player2 = new PlayerInfoOnScreen(CanvasPlayertwo, EPlayerId.Cat);
            ActualPosition2.Content = "Aktualna Pozycja";
            Pocket2.Content = "Kasa: ";
            CurrentPosition2.Content = "Start";
            Player2Name.Content = "Kot";
            _myinfopanel.AddPlayerInfo(player2);

            PlayerInfoOnScreen player3 = new PlayerInfoOnScreen(CanvasPlayerthree, EPlayerId.Car);
            ActualPosition3.Content = "Aktualna Pozycja";
            Pocket3.Content = "Kasa: ";
            CurrentPosition3.Content = "Start";
            Player3Name.Content = "Auto";
            _myinfopanel.AddPlayerInfo(player3);

            PlayerInfoOnScreen player4 = new PlayerInfoOnScreen(CanvasPlayer4, EPlayerId.Canoon);
            ActualPosition4.Content = "Aktualna Pozycja";
            CurrentPosition4.Content = "Start";
            Pocket4.Content = "Kasa: ";
            Player4Name.Content = "Armata";
            _myinfopanel.AddPlayerInfo(player4);
            


            PlayerInfoOnScreen player5 = new PlayerInfoOnScreen(CanvasPlayer5, EPlayerId.Iron);
            ActualPosition5.Content = "Aktualna Pozycja";
            CurrentPosition5.Content = "Start";
            Pocket5.Content = "Kasa: ";
            Player5Name.Content = "Żelazko";
            _myinfopanel.AddPlayerInfo(player5);

            PlayerInfoOnScreen player6 = new PlayerInfoOnScreen(CanvasPlayer6, EPlayerId.Dog);
            ActualPosition6.Content = "Aktualna Pozycja";
            CurrentPosition6.Content = "Start";
            Pocket6.Content = "Kasa: ";
            Player6Name.Content = "Pies";
            _myinfopanel.AddPlayerInfo(player6);






        }


        private void InitializeBoard()
        {
            _myboard = new BoardPanel();
            foreach (IRefreshField field in _myboard.Fields)
            {
                my_grid.Children.Add(field.getCanvas());
            }
            _myboard.Fields[0].SetMargin(775, 755, 0, 0);

            int a = 685;
            for (int i = 1; i < 10; i++)
            {
                _myboard.Fields[i].SetMargin(a, 755, 0, 0);
                a -= 71;
            }

            _myboard.Fields[10].SetMargin(0, 775, 0, 0);

            int b = 680;
            for (int i = 11; i < 20; i++)
            {
                _myboard.Fields[i].SetMargin(0, b, 0, 0);
                b -= 71;
            }

            _myboard.Fields[20].SetMargin(0, 0, 0, 0);

            int c = 115;
            for (int i = 21; i < 30; i++)
            {
                _myboard.Fields[i].SetMargin(c, 0, 0, 0);
                c += 71;
            }


            _myboard.Fields[30].SetMargin(755, 0, 0, 0);

            int d = 113;
            for (int i = 31; i < 40; i++)
            {
                _myboard.Fields[i].SetMargin(755, d, 0, 0);
                d += 71;
            }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
        /// <summary>
        /// Metoda ta imituje ruch gracza na plaszy
        /// </summary>
        /// <param name="step"></param>
        public void movePlayer(int step) 
        {
            Player currentPlayer = _engine.GameStatus.GetCurrentPlayer();
            for (int i = 0; i < step; i++)
            {
                currentPlayer.Coordinates = (currentPlayer.Coordinates + 1) % 40;
                this.Dispatcher.Invoke(new Action(() => { _myboard.GroupedRefresh(); }));
                Thread.Sleep(500);
            }
            RefreshPlayerInfo();
        }

        /// <summary>
        /// metoda ta odświeża informacje na temat gracza
        /// </summary>
        public void RefreshPlayerInfo()
        {
            this.Dispatcher.Invoke(new Action(() => { _myinfopanel.UpdatePlayerInfo(); }));
        }

        /// <summary>
        /// Umieszcza Informacje na ekranie
        /// </summary>
        /// <param name="txt"></param>
        public void DisplayTransientNotice(string txt)
        {
            try
            {
                ListBoxWithAction.Visibility = Visibility.Collapsed;
                TransientText.Text = txt;
                TransientCanvas.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                // ignore for a while
                Console.WriteLine(ex.ToString());   
            }            
        }

        /// <summary>
        /// Usuwa informacje z ekrana i dodaje panel możliwych akcji
        /// </summary>
        public void HideTransientNotice()
        {
            ListBoxWithAction.Visibility = Visibility.Visible;
            TransientText.Text = "";
            TransientCanvas.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// animacja rzutu kostką
        /// </summary>
        /// <param name="rec"></param>
        public void ShowImage(DiceThrowRecord rec) 
        {
            string path = Environment.CurrentDirectory;
            BitmapImage bitmap = new BitmapImage();
            BitmapImage bitmap2 = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@$"{path}/DiceThrow{rec.FirstThrow}.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            bitmap2.BeginInit();
            bitmap2.UriSource = new Uri(@$"{path}/DiceThrow{rec.SecondThrow}.png", UriKind.RelativeOrAbsolute);
            bitmap2.EndInit();

            firstDice.Source = bitmap;
            secondDice.Source = bitmap2;
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() => { GameStatus.SaveToFile("Autosave.xml", _engine.GameStatus); }));
       
            Close();
        }

        private void SaveGame(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".xml"; // Default file extension
            dialog.Filter = "Xml documents (.xml)|*.xml"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dialog.FileName;
                this.Dispatcher.Invoke(new Action(() => { GameStatus.SaveToFile(filename, GameStatus.Instance); }));
            }
          
        }

        /// <summary>
        /// Po kliknieciu w przycisk zostanie wczytana gra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGame(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".xml"; // Default file extension
            dialog.Filter = "Text documents (.xml)|*.xml"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                GameEngine.Engine.GameStatus = GameStatus.LoadfromFile(filename);  
            }
            GameEngine.Engine.GameStatus.initStaticData();
            _myboard.GroupedRefresh();
            _myinfopanel.UpdatePlayerInfo();
            GameStatus currentGameStatus = GameEngine.Engine.GameStatus;
            GroupedCheckIsActivePlayerInfoAdjust(currentGameStatus);

            GameEngine.Engine.RunGame();
        }

        public Window GetMainWindow() 
        {
            return mainwindow;
        }

        /*
        Window win2 = new Window();
        Grid secondGrid = new Grid();
        win2.Content = secondGrid;
        Canvas helpCanvas= new Canvas();
        helpCanvas.Width = 100;
        helpCanvas.Height = 40;
        helpCanvas.Margin = new Thickness(100,100,0,0);
        TextBox newtextbox = new TextBox();
        helpCanvas.Children.Add(newtextbox);
        newtextbox.Height = 40;
        newtextbox.Width = 100;


        string kot = newtextbox.Text;
        secondGrid.Children.Add(newtextbox);
        Button closebutton = new Button();
        win2.Show();

        GameStatus.LoadfromFile("kot");
        */


        /// <summary>
        /// po kliknięciu w przycisk tworzy domyślną rozgrywkę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void NewGame(object sender, RoutedEventArgs e)
        {

            if (MessageBoxResult.Yes.Equals(MessageBox.Show("Zaczynamy od nowa. Jesteś pewien?","Nowa gra",MessageBoxButton.YesNo)))
            {
                if (MessageBoxResult.Yes.Equals((MessageBox.Show("Czy chcesz włączyć autosave Po Każdej kolejce ", "Opcja Autosave", MessageBoxButton.YesNo))))
                {
                    _engine.IsAutosaveOptionAvalaibe = true;
                }
                List<Player> list = new List<Player>();
                list.Add(new Player("Slon", EPlayerId.Elephant));
                list.Add(new Player("Kot", EPlayerId.Cat));
                list.Add(new Player("Auto", EPlayerId.Car));
                list.Add(new Player("Armata", EPlayerId.Canoon));

                GameStatus.Instance.InitiateNewGame(list);
                GameStatus.Instance.initStaticData();
                RefreshAll();

                GameStatus currentGameStatus = GameStatus.Instance;
                GroupedCheckIsActivePlayerInfoAdjust(currentGameStatus);

                _engine.RunGame();
            }
            

        }

        /* ForEasierTesting
        public DiceThrowRecord getChatThrow()
        {
            DiceThrowRecord retVal = new DiceThrowRecord();
            retVal.FirstThrow = Int16.Parse(t1);
            retVal.SecondThrow = Int16.Parse(t2);
            return retVal;
        }
        */


        /// <summary>
        /// ta metoda odświeża wszysko na ekranie
        /// </summary>

        public void RefreshAll()
        {
            _myboard.GroupedRefresh();
            _myinfopanel.UpdatePlayerInfo();
        }

        //for EasierTesting
        private void firstthrow_TextChanged(object sender, TextChangedEventArgs e)
        {
            //t1 = firstthrow.Text;
        }

        private void secondthhrow_TextChanged(object sender, TextChangedEventArgs e)
        {
            //t2 = secondthhrow.Text;
        }
        static private void MediaEnded(object sender, EventArgs e)
       {
           myPlayer.Position = TimeSpan.Zero;
           myPlayer.Play();
       }

        /// <summary>
        /// ta metoda pozwala uruchomić muzykę w tle
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="loop"></param>
        static public void PlayMusic(string filename, bool loop)
        {


             string path = Environment.CurrentDirectory;

             string path_final = path + $@"\{filename}.mp3";
             myPlayer.Open(new System.Uri(path_final));
             myPlayer.Play();
             if (loop) 
                 myPlayer.MediaEnded +=  new EventHandler(MediaEnded) ;


     }
        static public void PlaySound(string file_name)
        {
            string path = Environment.CurrentDirectory;
            string path_final = path + $@"/{file_name}" + ".mp3";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(path_final);
            player.Play();
        }
    }
}

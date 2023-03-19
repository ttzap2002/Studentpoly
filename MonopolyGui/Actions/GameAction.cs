using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MonopolyGui;
using static System.Net.Mime.MediaTypeNames;

namespace MonopolyGui.Actions
{
    public abstract class GameAction
    {


        string imagesource;
        string actionlabel;
  

        public string Imagesource { get => imagesource; }
        public string Actionlabel { get => actionlabel; }

        public GameAction(string imagesource, string actionlabel)
        {
            this.imagesource = imagesource;
            this.actionlabel = actionlabel;
           
        }

        private void DisplayTN(string txt, int delay)
        {
            MainWindow.Instance.Dispatcher.Invoke(new Action(() => { MainWindow.Instance.DisplayTransientNotice(txt); }));
            Thread.Sleep(delay);
            MainWindow.Instance.Dispatcher.Invoke(new Action(() => { MainWindow.Instance.HideTransientNotice(); }));

        }
        protected void DisplayTN()
        {
            DisplayTN(actionlabel, 5000);
        }

        protected void DisplayShortTN(string txt)
        {
            DisplayTN(txt, 1000);
        }

        protected void DisplayShortTN()
        {
            DisplayTN(actionlabel, 1000);
        }

        protected void DisplayTN(string txt)
        {
            DisplayTN(txt, 5000);
        }

        protected void RefreshScreen()
        {
            MainWindow.Instance.Dispatcher.Invoke(new Action(() => { MainWindow.Instance.RefreshAll(); }));

        }

        /// <summary>
        /// metoda ta uruchamia akcje, może choć nie zawsze dodawać kolejne akcje do GameEngine
        /// </summary>
        async public virtual void Run()
        {

        }

       



    }
}

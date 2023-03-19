using MonopolyGui.Actions;
using MonopolyLogic;
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




namespace MonopolyGui
{
    public class ActionPanel
    {   
        ListBox _actionlistbox;
        
        public ActionPanel(ListBox actionlistbox)
        {


            Actionlistbox = actionlistbox;
            
            //ActiontextBox = actiontextBox;
        }

        public ListBox Actionlistbox { get => _actionlistbox; set => _actionlistbox = value; }
        //public TextBox ActiontextBox { get => actiontextBox; set => actiontextBox = value; }

        public void ChangeVisibility() 
        {
            _actionlistbox.Visibility = Visibility.Hidden;
        }

        public void RemoveButtonsFromListBox() 
        {
            _actionlistbox.Items.Clear();
            //< Label Width = "380" FontSize = "22" Margin = "90,0,0,0" > </ Label >
            Label l  = new Label();
            l.Width = 380;
            l.FontSize = 22;
            l.Margin= new Thickness(90,0,0,0);
            l.Content = $"{GameEngine.Engine.GameStatus.GetCurrentPlayer().Name} - wybierz akcję";
            _actionlistbox.Items.Add(l);
            
        }

        
        public void CreateActionButtons(List<GameAction> list) 
        {
            RemoveButtonsFromListBox();
            foreach (GameAction a in list)
            {
                _actionlistbox.Items.Add(new DynamicButton(a));
            }
        }

        public void SetMarginForButton() 
        {
            int a = 0;
           
            foreach(Button item in Actionlistbox.Items) 
            {
         
                item.Height= 55;
                item.Width= Actionlistbox.Width-20;
                a++;
      
            }
        }


    }
}

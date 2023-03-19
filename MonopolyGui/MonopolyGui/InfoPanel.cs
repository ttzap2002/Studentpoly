using MonopolyData;
using System;
using System.Collections.Generic;
using System.Windows.Controls;


namespace MonopolyGui
{
    public class InfoPanel
    {
        Canvas mainInfoCanvas;
        List<PlayerInfoOnScreen> playerInfo=new List<PlayerInfoOnScreen>();
        public InfoPanel(Canvas maininfocanvas)
        {
            Maininfocanvas = maininfocanvas;
        }

        public Canvas Maininfocanvas { get => mainInfoCanvas; set => mainInfoCanvas = value; }
        public List<PlayerInfoOnScreen> Playerinfo { get => playerInfo; set => playerInfo = value; }

        public void AddPlayerInfo(PlayerInfoOnScreen playerinfotoadd) 
        {
            Playerinfo.Add(playerinfotoadd);         
        }

        public void UpdatePlayerInfo() 
        {
            foreach(PlayerInfoOnScreen playerinfo in Playerinfo) 
            {
                playerinfo.RefreshPlayerInfoOnScreen();
                playerinfo.RefreshProperty();
            }
        }

        public void UpdatePlayerNameIfNewGameStart() 
        {
            int i = 0;
            foreach(PlayerInfoOnScreen playerInfo in Playerinfo) 
            {

                ((Label)playerInfo.Infocanvas.Children[0]).Content = GameStatus.Instance.Players[i].Name;
                i++;
            }
        }
    }
}

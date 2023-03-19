using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace MonopolyData
{
    [Serializable]

    public class Player : IEquatable<Player>,ICloneable
    {
        EPlayerId playerId;
        int coordinates=0;
        int wallet=1500;
        bool isActive=true;
        int turnsToStayInPrison = 0;
        int exitPrisonCards = 0;
        string name;

        public Player() 
        {
            
        }

        public Player(string name, EPlayerId playerid)
        {
       
            Name = name;
            PlayerId = playerid;
        }

        public int Coordinates { get => coordinates; set => coordinates = value; }
        public int Wallet { get => wallet; set => wallet = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public int TurnsToStayInPrison { get => turnsToStayInPrison; set => turnsToStayInPrison = value; }
        public int ExitPrisonCards { get => exitPrisonCards; set => exitPrisonCards = value; }
        public string Name { get => name; set => name = value; }
        public EPlayerId PlayerId { get => playerId; set => playerId = value; }

        public bool IsPrisoner()
        {
            return turnsToStayInPrison > 0;
        }
        public bool Equals(Player? other)
        {
            if (other.PlayerId == this.PlayerId)
                return true;
            return false;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

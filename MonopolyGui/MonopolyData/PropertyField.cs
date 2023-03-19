using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyData
{
    [Serializable]
    public class PropertyField : Field
    {
        EPlayerId owner;
        bool isMortgage=false;
        int price;


        public PropertyField() 
        {

        }

        public PropertyField(string fieldname,int coordinates) :base(fieldname,coordinates)
        {
            
        }

        public EPlayerId Owner { get => owner; set => owner = value; }
        public bool IsMortgage { get => isMortgage; set => isMortgage = value; }
        public int Price { get => price; set => price = value; }
    

    
    }
}

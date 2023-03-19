using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyData
{
    [Serializable]
    public class Field
    {
        string fieldname;
        int coordinate;

        
        public Field() { }

        public Field(string fieldname, int coordinates)
        {
            Fieldname = fieldname;
            Coordinates = coordinates;
        }

        public string Fieldname { get => fieldname; set => fieldname = value;}
        public int Coordinates { get => coordinate; set => coordinate = value;}

      
    }
}

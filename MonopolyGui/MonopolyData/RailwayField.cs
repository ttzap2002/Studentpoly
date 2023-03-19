using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyData
{
    [Serializable]
    public class RailwayField :PropertyField
    {
        public RailwayField(string fieldname, int coordinates) : base(fieldname, coordinates)
        {

        }

        public RailwayField() { }
    }
}

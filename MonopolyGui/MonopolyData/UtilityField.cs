using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyData
{
    [Serializable]
    public class UtilityField :PropertyField
    {        
        public UtilityField(string fieldname, int coordinates) :base(fieldname,coordinates)
        {

        }

        public UtilityField() { }   
    }
}

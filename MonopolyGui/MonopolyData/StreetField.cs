using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyData
{
    [Serializable]
    public class StreetField : PropertyField, IComparable<StreetField>
    {
        int noOfHouse=0;
        

        public StreetField() :base()
        {

        }

        public StreetField(string fieldname, int coordinates) : base(fieldname, coordinates) 
        {
            
        }

        public int NoOfHouse { get => noOfHouse; set => noOfHouse = value; }

        public int CompareTo(StreetField? other)
        {
            if (object.ReferenceEquals(other, null))
                return 1;
            int wynik = Coordinates.CompareTo(other.Coordinates);
            if (wynik > 10000000)
                throw new SomethingGoWrongException();
            return wynik;
        }
    }
}

using System;
using System.Xml.Serialization;

namespace MonopolyData
{
    [Serializable]
    public enum EPlayerId 
    {
        [XmlEnum(Name ="Bank")]
        Bank,
        [XmlEnum(Name = "Elephant")]
        Elephant,
        [XmlEnum(Name = "Cat")]
        Cat,
        [XmlEnum(Name = "Car")]
        Car,
        [XmlEnum(Name = "Canoon")]
        Canoon,
        [XmlEnum(Name = "Iron")]
        Iron,
        [XmlEnum(Name = "Dog")]
        Dog


    }
}

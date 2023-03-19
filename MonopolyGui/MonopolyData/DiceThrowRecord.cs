using System;
using System.Runtime.ExceptionServices;

namespace MonopolyData
{
    [Serializable]
    public struct DiceThrowRecord 
    {
        public int FirstThrow;
        public int SecondThrow;

        public DiceThrowRecord(int first, int second)
        {
            FirstThrow = first;
            SecondThrow = second;
        }
        public bool IsDouble() { return FirstThrow == SecondThrow; }
        public int Sum() { return FirstThrow + SecondThrow; }
    }
}
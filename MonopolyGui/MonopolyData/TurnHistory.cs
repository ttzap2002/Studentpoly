using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace MonopolyData
{
    [Serializable]
    public partial class TurnHistory
    {
        List<DiceThrowRecord> _records;
        MandatoryAction _mandatoryAction;
        int _housesBought;

        public List<DiceThrowRecord> Records { get => _records; set => _records = value; }
        public MandatoryAction MandatoryAction { get => _mandatoryAction; set => _mandatoryAction = value; }
        public int HousesBought { get => _housesBought; set => _housesBought = value; }

        public TurnHistory() 
        { 
            _records = new List<DiceThrowRecord>();
            _mandatoryAction = null;
            _housesBought = 0;
        }

        public bool HasMovedInTheTurn() { return _records.Count > 0; }

        public bool IsLastThrowDouble()
        {
            if (_records.Count > 0)
            {
                return _records[_records.Count - 1].IsDouble();
            }
            return false;
        }

        public void RegisterMove(DiceThrowRecord r) 
        {
            _records.Add(r);
        }

        public int NumberOfDoubles() => Records.Where(x=>x.IsDouble()).Count();

        public int SumAllThrows() => Records.Sum(x=>x.Sum());
        

        internal bool HasMandatoryAction()
        {
            return MandatoryAction != null ;
        }

        public void RegisterMandatoryAction(EPlayerId payTo, int amount)
        {
            MandatoryAction = new MandatoryAction(payTo, amount);

        }
    }
}
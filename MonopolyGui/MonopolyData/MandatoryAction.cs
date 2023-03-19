using System;

namespace MonopolyData
{
    [Serializable]
    public class MandatoryAction
    {
        private EPlayerId _payTo;
        private int _amount;

        public EPlayerId PayTo { get => _payTo; set => _payTo = value; }
        public int Amount { get => _amount; set => _amount = value; }

        public MandatoryAction() { }
        public MandatoryAction(EPlayerId payTo, int amount)
        {
            PayTo = payTo;
            Amount = amount;
        }
    }

}
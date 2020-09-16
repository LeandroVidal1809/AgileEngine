using System;

namespace AgileEngineSite
{
    public class TransactionResponse
    {
        public TransactionResponse() { }
        public int Id { get; set; }
        public TypeEnum Type { get; set; }
        public decimal Amount { get; set; }
      
        public DateTime DateTime { get; set; }
        public decimal AmountSum
        {
            get
            {
                if (Type == TypeEnum.debit)
                    return Amount * -1;
                else
                    return Amount;
            }
        }
    }

    public enum TypeEnum
    {
        credit = 1,
        debit = 2
    }


}

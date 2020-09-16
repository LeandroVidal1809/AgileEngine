using System;

namespace AgileEngineApi
{
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionEnum Type { get; set; }
        public decimal Amount { get; set; }

        public DateTime DateTime { get; set; }
    }

    public enum TransactionEnum
    {
        Credit =1 ,
        Debit = 2
    }
}

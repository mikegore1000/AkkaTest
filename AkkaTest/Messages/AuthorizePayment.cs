using System;

namespace AkkaTest.Messages
{
    public class AuthorizePayment
    {
        public AuthorizePayment(int paymentRefernce, Amount amount)
        {
            PaymentReference = paymentRefernce;
            Amount = amount;
        }

        public Amount Amount { get; private set; }

        public int PaymentReference { get; private set; }
    }

    public class Amount
    {
        public Amount(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }

        public Currency Currency { get; private set; }

        public decimal Value { get; private set; }
    }

    public enum Currency
    {
        GBP
    }
}

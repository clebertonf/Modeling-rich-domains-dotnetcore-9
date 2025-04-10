﻿using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment
{
    public CreditCardPayment(DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email, int cardHolderName, int cardNumber, int lastTransactionNumber)
        : base(paidDate, expiredDate, total, totalPaid, payer, document, address, email)
    {
        CardHolderName = cardHolderName;
        CardNumber = cardNumber;
        LastTransactionNumber = lastTransactionNumber;
    }

    public int CardHolderName { get; private set; }
    public int CardNumber { get; private set; }
    public int LastTransactionNumber { get; private set; }
}
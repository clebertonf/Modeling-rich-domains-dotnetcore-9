﻿using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PayPalPayment : Payment
{
    public PayPalPayment(DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email, int transactionCode)
        : base(paidDate, expiredDate, total, totalPaid, payer, document, address, email)
    {
        TransactionCode = transactionCode;
    }
    
    public int TransactionCode { get; private set; }
}
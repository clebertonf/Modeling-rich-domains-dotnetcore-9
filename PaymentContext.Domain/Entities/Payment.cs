﻿using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public abstract class Payment : Entity
{
    protected Payment(DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email)
    {
        Number = Guid.NewGuid().ToString().Replace("-","").Substring(0, 10).ToUpper();
        PaidDate = paidDate;
        ExpiredDate = expiredDate;
        Total = total;
        TotalPaid = totalPaid;
        Payer = payer;
        Document = document;
        Address = address;
        Email = email;
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(0, Total, nameof(Total), "Total must be greater than 0.")
            .IsGreaterOrEqualsThan(Total, TotalPaid, nameof(TotalPaid), "The amount paid is less than the payment amount"));
    }

    public string Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpiredDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public string Payer { get; private set; }
    public Document Document { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get;  private set; }

}
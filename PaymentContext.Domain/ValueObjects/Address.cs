﻿using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsLowerThan(Street, 3, nameof(street), "Street cannot be less than 3 digits")
            .IsGreaterThan(Street, 50, nameof(street), "Street cannot be more than 50 digits"));
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
}
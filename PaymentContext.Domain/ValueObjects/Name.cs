using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        if(string.IsNullOrEmpty(firstName))
            AddNotification("Name.FirstName", "FirstName cannot be empty");
        
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsLowerThan(FirstName, 3, nameof(firstName), "FirstName cannot be less than 3 digits")
            .IsGreaterThan(FirstName, 50, nameof(firstName), "FirstName cannot be more than 50 digits")
            .IsLowerThan(LastName, 3, nameof(lastName), "LastName cannot be less than 3 digits")
            .IsGreaterThan(LastName, 50, nameof(lastName), "LastName cannot be more than 50 digits"));
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}
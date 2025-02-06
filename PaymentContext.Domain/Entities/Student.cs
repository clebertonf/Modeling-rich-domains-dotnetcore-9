using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    private readonly IList<Subscription> _subscriptions;
    public Student(Name name, Document document, Email email, Address address)
    {
        Name = name;
        Document = document;
        Email = email;
        Address = address;
        _subscriptions = new List<Subscription>();
        
        AddNotifications(name, document, email);
    }

    public Name Name { get; private set; } 
    public Document Document { get; private set; }
    public Email Email { get;  private set; }
    public Address Address { get; private set; }
    private IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.ToArray();

    public void AddSubscription(Subscription subscription)
    {
        var hasSubscriptionActive = false;
        
        foreach (var sub in _subscriptions)
        {
            if(sub.IsActive)
                hasSubscriptionActive = true;
        }
        
       /* AddNotifications(new Contract<Notification>()
            .Requires()
            .IsFalse(hasSubscriptionActive, nameof(Student.Subscriptions),"Subscription is already in active"));
       */
        
        // Alternative
        if(hasSubscriptionActive)
            AddNotification(nameof(Student.Subscriptions), "Subscription is already in active");
    }
}
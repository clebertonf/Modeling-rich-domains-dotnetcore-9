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
    }

    public Name Name { get; private set; } 
    public Document Document { get; private set; }
    public Email Email { get;  private set; }
    public Address Address { get; private set; }
    private IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.ToArray();

    public void AddSubscription(Subscription subscription)
    {
        foreach (var sub in Subscriptions)
        {
            sub.Activate(false);
        }
        _subscriptions.Add(subscription);
    }
}
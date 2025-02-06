using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Subscription : Entity
{
    private readonly IList<Payment> _payments;
    public Subscription(DateTime? expireDate)
    {
        CreateDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        ExpireDate = expireDate;
        IsActive = true;
        _payments = new List<Payment>();
    }

    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public bool IsActive { get; private set; }
    public IReadOnlyCollection<Payment> Payments => _payments.ToArray();

    public void AddPayment(Payment payment)
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(DateTime.Now, payment.PaidDate, nameof(payment.PaidDate), "Payment date must be in the future."));
        
        // if(valid)
        _payments.Add(payment);
    }

    public void Activate(bool isActive)
    {
        IsActive = isActive;
        LastUpdateDate = DateTime.Now;
    }
}
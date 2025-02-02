using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities;

public class StudentTests
{
    [Fact]
    public void StudentTest()
    {
        var subscription = new Subscription(null);
        var student = new Student("Cleberton", "Carvalho", "123456", "clebertonfgc@gmail.com", "test");
        student.AddSubscription(subscription);
    }
}
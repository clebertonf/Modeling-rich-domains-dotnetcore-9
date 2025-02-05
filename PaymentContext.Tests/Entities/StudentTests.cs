using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

public class StudentTests
{
    [Fact]
    public void StudentTest()
    {
        var name = new Name("FirstName", "FirstName");
        // name.Notifications;
    }
}
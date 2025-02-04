using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

public class StudentTests
{
    [Fact]
    public void StudentTest()
    {
        var subscription = new Subscription(null);
        var student = new Student(
            new Name("Cleberton", "Carvalho"),
            new Document("55555", EDocumentType.Cpf),
            new Email("clebertonfgc@gmail.com"),
            new Address("test1", "test2", "test3", "test4", "test5", "test6", "teste7"));
        
        student.AddSubscription(subscription);
    }
}
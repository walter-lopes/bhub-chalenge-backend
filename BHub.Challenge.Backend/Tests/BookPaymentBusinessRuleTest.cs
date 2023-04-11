using BHub.Challenge.Backend.Domain;
using NUnit.Framework;

namespace BHub.Challenge.Backend.Tests;

public class BookPaymentBusinessRuleTest
{
    [Test]
    public void Should_Generate_Duplicated_Delivery_Note_To_Royalties_Staff()
    {
        //Arrange
        var businessRule = new PhysicalProductBusinessRule();
        var payment = new Payment() {PaymentType = PaymentType.Book};
        
        //Act
        businessRule.ExecuteAsync(payment);
        
        //Asserts
    }
}
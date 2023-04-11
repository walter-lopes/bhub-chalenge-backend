using BHub.Challenge.Backend.Domain;
using NUnit.Framework;

namespace BHub.Challenge.Backend.Tests;

public class MembershipPaymentBusinessRuleTest
{
    [Test]
    public void Should_Send_Activation_Email()
    {
        //Arrange
        var businessRule = new MembershipPaymentBusinessRule();
        var payment = new Payment() {PaymentType = PaymentType.Membership};
        
        //Act
        businessRule.ExecuteAsync(payment);
        
        //Asserts
    }
}
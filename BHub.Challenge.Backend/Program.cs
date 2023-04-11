using BHub.Challenge.Backend;
using BHub.Challenge.Backend.Domain;
using Microsoft.Extensions.DependencyInjection;


var serviceCollection = new ServiceCollection();
serviceCollection.AddPaymentBusinessRules();
var provider = serviceCollection.BuildServiceProvider();

var payment = new Payment
{
    PaymentType = PaymentType.Book
};
await PostPayment(payment);

async Task PostPayment(Payment payment)
{
    var service = provider.GetService<Func<PaymentType, IPaymentBusinessRule>>();

    var businessRule = service?.Invoke(payment.PaymentType);
    await businessRule?.ExecuteAsync(payment)!;
}
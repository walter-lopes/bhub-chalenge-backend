using BHub.Challenge.Backend;
using BHub.Challenge.Backend.Domain;
using Microsoft.Extensions.DependencyInjection;


async Task PostPayment(Payment payment)
{
    var serviceCollection = new ServiceCollection();
    serviceCollection.AddPaymentBusinessRules();
    var provider = serviceCollection.BuildServiceProvider();
    
    var service = provider.GetService<Func<PaymentType, IPaymentBusinessRule>>();

    await service?.Invoke(payment.PaymentType).ExecuteAsync(payment)!;
}
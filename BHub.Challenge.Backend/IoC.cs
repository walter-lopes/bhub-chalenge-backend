using BHub.Challenge.Backend.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace BHub.Challenge.Backend;

public static class IoC
{
    public static IServiceCollection AddPaymentBusinessRules(this IServiceCollection services)
    {
        services.AddScoped<BookPaymentBusinessRule>();
        services.AddTransient<MembershipPaymentBusinessRule>();
        services.AddTransient<UpgradePaymentBusinessRule>();
        services.AddTransient<PhysicalProductBusinessRule>();
        
        services.AddTransient<Func<PaymentType, IPaymentBusinessRule>>(serviceProvider => key =>
        {
            return key switch
            {
                PaymentType.Book => serviceProvider.GetService<BookPaymentBusinessRule>(),
                PaymentType.Membership => serviceProvider.GetService<MembershipPaymentBusinessRule>(),
                PaymentType.Upgrade => serviceProvider.GetService<UpgradePaymentBusinessRule>(),
                PaymentType.PhysicalProduct => serviceProvider.GetService<PhysicalProductBusinessRule>(),
                _ => throw new Exception("Concrete class doesn't exist.")
            };
        });

        return services;
    }
    
}
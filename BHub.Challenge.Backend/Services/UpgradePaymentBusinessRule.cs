using BHub.Challenge.Backend.Domain;

namespace BHub.Challenge.Backend;

public class UpgradePaymentBusinessRule : IPaymentBusinessRule
{
    public Task ExecuteAsync(Payment payment)
    {
        // Running Upgrade Payment Business Rule
        throw new NotImplementedException();
    }
}
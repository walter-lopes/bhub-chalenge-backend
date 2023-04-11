using BHub.Challenge.Backend.Domain;

namespace BHub.Challenge.Backend;

public class MembershipPaymentBusinessRule : IPaymentBusinessRule
{
    public Task ExecuteAsync(Payment payment)
    {
        // Running Membership Payment Business Rule
        throw new NotImplementedException();
    }
}
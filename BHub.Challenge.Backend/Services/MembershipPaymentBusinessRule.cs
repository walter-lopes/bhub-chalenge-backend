using BHub.Challenge.Backend.Domain;

namespace BHub.Challenge.Backend;

public class MembershipPaymentBusinessRule : IPaymentBusinessRule
{
    public Task ExecuteAsync(Payment payment)
    {
        throw new NotImplementedException();
    }
}
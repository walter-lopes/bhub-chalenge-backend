using BHub.Challenge.Backend.Domain;

namespace BHub.Challenge.Backend;

public class BookPaymentBusinessRule : IPaymentBusinessRule
{
    public Task ExecuteAsync(Payment payment)
    {
        throw new NotImplementedException();
    }
}
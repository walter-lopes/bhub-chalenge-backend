using BHub.Challenge.Backend.Domain;

namespace BHub.Challenge.Backend;

public class BookPaymentBusinessRule : IPaymentBusinessRule
{
    public async Task ExecuteAsync(Payment payment)
    {
        // Running Book Payment Business Rule
        await Task.CompletedTask;
    }
}
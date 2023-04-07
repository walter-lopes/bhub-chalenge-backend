using BHub.Challenge.Backend.Domain;

namespace BHub.Challenge.Backend;

public interface IPaymentBusinessRule
{
    Task ExecuteAsync(Payment payment);
}
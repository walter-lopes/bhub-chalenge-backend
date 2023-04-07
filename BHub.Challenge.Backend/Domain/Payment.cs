namespace BHub.Challenge.Backend.Domain;

public class Payment
{
    public PaymentType PaymentType { get; set; }
}

public enum PaymentType
{
    Book = 1,
    Membership = 2,
    PhysicalProduct = 3,
    Upgrade = 4
}
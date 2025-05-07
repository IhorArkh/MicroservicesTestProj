namespace Ordering.Domain.Models.ValueObjects;

public class Payment
{
    public string? CardName { get; } = null!;
    public string CardNumber { get; } = null!;
    public string Expiration { get; } = null!;
    public string CVV { get; } = null!;
    public int PaymentMethod { get; }
}
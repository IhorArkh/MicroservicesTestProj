namespace Ordering.Domain.Models;

public class Order : Aggregate<Guid>
{
    private readonly List<OrderItem> _orderItems = [];
    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public Guid CustomerId { get; private set; }
    public string OrderName { get; private set; } = null!;
    public Address ShippingAdress { get; private set; } = null!;
    public Address BillingAdress { get; private set; } = null!;
    public Payment Payment { get; private set; } = null!;
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;

    public decimal TotalPrice
    {
        get => OrderItems.Sum(x => x.Price * x.Quantity);
        private set { }
    }

}
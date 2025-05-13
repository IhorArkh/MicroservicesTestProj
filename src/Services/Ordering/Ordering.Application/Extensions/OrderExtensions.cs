namespace Ordering.Application.Extensions;

public static class OrderExtensions
{
    public static IEnumerable<OrderDto> ToOrderDtoList(this IEnumerable<Order> orders)
    {
        var ordersDtos = new List<OrderDto>();

        foreach (var order in orders)
        {
            var orderDto = new OrderDto(
                Id: order.Id.Value,
                CustomerId: order.CustomerId.Value,
                OrderName: order.OrderName.Value,
                ShippingAddress: new AddressDto(
                    FirstName: order.ShippingAddress.FirstName,
                    LastName: order.ShippingAddress.LastName,
                    EmailAddress: order.ShippingAddress.EmailAddress,
                    AddressLine: order.ShippingAddress.AddressLine,
                    Country: order.ShippingAddress.Country,
                    State: order.ShippingAddress.State,
                    ZipCode: order.ShippingAddress.ZipCode),
                BillingAddress: new AddressDto(
                    order.BillingAddress.FirstName,
                    order.BillingAddress.LastName,
                    order.BillingAddress.EmailAddress,
                    order.BillingAddress.AddressLine,
                    order.BillingAddress.Country,
                    order.BillingAddress.State,
                    order.BillingAddress.ZipCode),
                Payment: new PaymentDto(
                    order.Payment.CardName,
                    order.Payment.CardNumber,
                    order.Payment.Expiration,
                    order.Payment.CVV,
                    order.Payment.PaymentMethod),
                Status: order.Status,
                OrderItems: order.OrderItems.Select(x
                    => new OrderItemDto(x.OrderId.Value, x.ProductId.Value, x.Quantity, x.Price)).ToList());

            ordersDtos.Add(orderDto);
        }

        return ordersDtos;
    }
}
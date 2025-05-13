namespace Ordering.Application.Orders.EventHandlers;

public class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent orderCreatedEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", orderCreatedEvent.GetType().Name);
        return Task.CompletedTask;
    }
}
namespace Ordering.Application.Orders.Commands.CreateFolder;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        // create order entity from command obj.
        // save order entity to db.
        // return result.

        throw new NotImplementedException();
    }
}
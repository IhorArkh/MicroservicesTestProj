namespace Ordering.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(OrderDto orderDto) : ICommand<CreateOrderResult>;

public record CreateOrderResult(Guid Id);

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.orderDto.OrderName).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.orderDto.CustomerId).NotNull().WithMessage("CustomerId is required");
        RuleFor(x => x.orderDto.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
    }
}
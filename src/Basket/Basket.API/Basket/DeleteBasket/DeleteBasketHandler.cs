namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

public record DeleteBasketResult(bool IsSuccess);

public class DeleteBasketCommmandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommmandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required.");
    }
}

public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        // TODO: Delete basket from database.

        return new DeleteBasketResult(true);
    }
}
﻿namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

public record DeleteBasketResult(bool IsSuccess);

public class DeleteBasketCommmandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommmandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required.");
    }
}

public class DeleteBasketCommandHandler(IBasketRepository basketRepository)
    : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        var result = await basketRepository.DeleteBasket(command.UserName, cancellationToken);

        return new DeleteBasketResult(result);
    }
}
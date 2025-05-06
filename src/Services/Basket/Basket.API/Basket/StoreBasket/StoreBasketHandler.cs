using Discount.Grpc;

namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart ShoppingCart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.ShoppingCart).NotNull().WithMessage("Shopping cart can not be null.");
        RuleFor(x => x.ShoppingCart.UserName).NotEmpty().WithMessage("UserName is required.");
    }
}

public class StoreBasketCommandHandler(
    IBasketRepository basketRepository,
    DiscountProtoService.DiscountProtoServiceClient discountProto)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        await ApplyDiscount(command.ShoppingCart, cancellationToken);

        await basketRepository.StoreBasket(command.ShoppingCart, cancellationToken);

        return new StoreBasketResult(command.ShoppingCart.UserName);
    }

    private async Task ApplyDiscount(ShoppingCart shoppingCart, CancellationToken cancellationToken)
    {
        foreach (var shoppingCartItem in shoppingCart.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(
                new GetDiscountRequest() { ProductName = shoppingCartItem.ProductName },
                cancellationToken: cancellationToken);

            shoppingCartItem.Price -= coupon.Amount;
        }
    }
}
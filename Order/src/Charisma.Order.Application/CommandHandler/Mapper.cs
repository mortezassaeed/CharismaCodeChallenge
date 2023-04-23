using Charisma.Framework.Application.Configurations;
using Charisma.Order.Application.Contract.Commands;
using Charisma.Order.Domain.CartAggregate;

namespace Charisma.Order.Application.CommandHandler;
public static class CartCommandMapper
{
	public static Cart ToCart(this AddCartCommand command, IClock clock)
	{
		var items = command.ProductIds.Select(p =>
		{
			var item = new CartItem();
			item.AddProduct(p);
			return item;
		}).ToList();

		var cart = new Cart(clock.GetCurrentDateTime(), command.CustomerId);
		cart.CartItems = items;
		return cart;
	}
}

using Charisma.Order.Domain.CartAggregate;

namespace Charisma.Order.Application.Contract.QueryServices.DTOs;

public static class CartDtoExtension
{
	public static CartDto ToCartDto(this Cart cart)
	{
		var cartItemDto = cart.CartItems.Select(m => new CartItemDto { Product = m.Product.Name }).ToList();

		return new CartDto()
		{
			Id = cart.Id,
			CustomerId = cart.CustomerId,
			Items = cartItemDto
		};
	}

}

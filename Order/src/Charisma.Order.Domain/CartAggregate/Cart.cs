using Charisma.Framework.Domain.Concrete;
using Charisma.Order.Domain.Exceptions;

namespace Charisma.Order.Domain.CartAggregate;

public class Cart : AggregateRoot<Guid>
{
	public DateTime OrderDateTime { get; private set; }

	public int CustomerId { get; set; }

	public ICollection<CartItem> CartItems { get; set; }
    public Cart(DateTime orderDateTime, int customerId)
	{

		if (orderDateTime.TimeOfDay <=
			TimeOnly.Parse("8:00 am").ToTimeSpan() ||
			orderDateTime.TimeOfDay >=
			TimeOnly.Parse("15:00 pm").ToTimeSpan()
			)
		{
			throw new CartOutOfPossibleTime();
		}

		if (customerId == 0) // It means no one
		{
			throw new CartCustomerIsRequired();
		}

		OrderDateTime = orderDateTime;
		CustomerId = customerId;
	}

	public void AddCartItem(CartItem cartItem)
	{
		CartItems.Add(cartItem);
	}
}
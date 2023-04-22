namespace Charisma.Order.Domain.Exceptions;

public class CartCustomerIsRequired : Exception
{
	public CartCustomerIsRequired() : base("Cart should have customer") { }
}


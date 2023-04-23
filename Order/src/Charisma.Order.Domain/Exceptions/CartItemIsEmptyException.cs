namespace Charisma.Order.Domain.Exceptions;

public class CartItemIsEmptyException : Exception
{
	public CartItemIsEmptyException() : base("You should add at least one item to your cart.") { }
}
public class SumOfProductPriceIsLessThanAllowed : Exception
{
	public SumOfProductPriceIsLessThanAllowed() : base("...") { }
}

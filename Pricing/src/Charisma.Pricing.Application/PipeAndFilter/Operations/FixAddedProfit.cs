using Charisma.Framework.Domain.CommonValueObject;

namespace Charisma.Pricing.Application.PipeAndFilter.Operations;

internal class FixAddedProfit : IOperation
{
	private readonly decimal _amount;

	public FixAddedProfit(decimal amount)
	{
		_amount = amount;
	}

	public Price Apply(Price price)
	{
		price.Value += _amount;
		return price;
	}
}


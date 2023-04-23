using Charisma.Framework.Domain.CommonValueObject;

namespace Charisma.Pricing.Application.PipeAndFilter.Conditions;

internal class ProductActualPriceMoreThanAmount : ICondition
{
	private readonly decimal _amount;
	public ProductActualPriceMoreThanAmount(decimal amount)
	{
		_amount = amount;
	}

	public bool IsSatisfiedBy(int customerId, Price actualPrice)
		=> actualPrice.Value > _amount;

}

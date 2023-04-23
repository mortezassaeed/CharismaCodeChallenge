using Charisma.Framework.Domain.CommonValueObject;

namespace Charisma.Pricing.Application.PipeAndFilter.Operations;

internal class FixAmountDiscount : IOperation
{
	private readonly decimal _amountOfDiscount;
	private readonly decimal _actualAmount;

	public FixAmountDiscount(decimal amountOfDiscount, decimal actualAmount)
	{
		_amountOfDiscount = amountOfDiscount;
		_actualAmount = actualAmount;
	}

	public Price Apply(Price price)
	{
		var discount = _actualAmount - _amountOfDiscount;
		price.Value -= discount;
		return price;
	}
}


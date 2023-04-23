using Charisma.Framework.Domain.CommonValueObject;

namespace Charisma.Pricing.Application.PipeAndFilter.Operations;

internal class PercentDiscount : IOperation
{
	private readonly decimal _percentAmountOfDiscount;
	private readonly decimal _actualAmount;

	public PercentDiscount(decimal percentAmountOfDiscount, decimal actualAmount)
	{
		_percentAmountOfDiscount = percentAmountOfDiscount;
		_actualAmount = actualAmount;
	}

	public Price Apply(Price price)
	{
		var discount = (_percentAmountOfDiscount * _actualAmount) / 100;
		price.Value -= discount;
		return price;
	}
}


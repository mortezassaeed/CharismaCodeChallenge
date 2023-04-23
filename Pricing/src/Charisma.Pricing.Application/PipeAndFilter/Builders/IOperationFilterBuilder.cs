namespace Charisma.Pricing.Application.PipeAndFilter.Builders;

public interface IOperationFilterBuilder
{
	IConditionFilterBuilder ApplyFixAddedProfit(decimal amount);
	IConditionFilterBuilder ApplyFixAmountDiscount(decimal amount);
	IConditionFilterBuilder ApplyPercentDiscount(decimal percentAmountOfDiscount);
	IConditionFilterBuilder ThrowError(string message);
}

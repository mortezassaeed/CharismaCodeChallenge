using Charisma.Pricing.Application.PipeAndFilter.Filters;

namespace Charisma.Pricing.Application.PipeAndFilter.Builders;

public interface IFilterBuilder : IConditionFilterBuilder
{

}


public interface IConditionFilterBuilder
{
	IOperationFilterBuilder AnyOrder();

	IOperationFilterBuilder WhenSpecialCustomer();

	IOperationFilterBuilder WhenProductActualPriceMoreThan(decimal amount);

	IFilter Build(); 
}

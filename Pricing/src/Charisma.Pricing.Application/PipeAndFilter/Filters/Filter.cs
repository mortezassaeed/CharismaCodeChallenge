using Charisma.Framework.Domain.CommonValueObject;
using Charisma.Pricing.Application.PipeAndFilter.Conditions;
using Charisma.Pricing.Application.PipeAndFilter.Operations;

namespace Charisma.Pricing.Application.PipeAndFilter.Filters;

internal class Filter : IFilter
{
	private readonly ICondition _condition;
	private readonly IOperation _operation;
	private IFilter _next;


	public Filter(ICondition condition, IOperation operation)
	{
		_condition = condition;
		_operation = operation;
		_next = EndFilter.Instance;
	}

	public Price Apply(int customerId, Price actualPrice, Price finalPrice)
	{
		if (_condition.IsSatisfiedBy(customerId, actualPrice))
			finalPrice = _operation.Apply(finalPrice);

		return _next.Apply(customerId, actualPrice, finalPrice);
	}

	public void SetNextFilter(IFilter filter)
	{
		_next = filter;
	}
}
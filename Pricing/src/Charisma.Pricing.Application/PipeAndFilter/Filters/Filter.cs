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

	public Price Apply(int customerId, Price actualPrice, Price price)
	{
		if (_condition.IsSatisfiedBy(customerId, actualPrice))
			price = _operation.Apply(price);

		return _next.Apply(customerId, actualPrice, price);
	}

	public void SetNextFilter(IFilter filter)
	{
		_next = filter;
	}
}
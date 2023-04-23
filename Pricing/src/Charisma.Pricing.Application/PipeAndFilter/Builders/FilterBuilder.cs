using Charisma.Framework.Domain.CommonValueObject;
using Charisma.Pricing.Application.PipeAndFilter.Conditions;
using Charisma.Pricing.Application.PipeAndFilter.Filters;
using Charisma.Pricing.Application.PipeAndFilter.Operations;

namespace Charisma.Pricing.Application.PipeAndFilter.Builders;

public class FilterBuilder : IFilterBuilder, IOperationFilterBuilder
{
	private readonly List<IFilter> _filters = new List<IFilter>();
	private ICondition _currentCondition;

	private readonly int _customerId;
	private readonly Price _actualPrice;

	public FilterBuilder(int customerId, Price actualPrice)
	{
		_customerId = customerId;
		_actualPrice = actualPrice;
	}

	public IConditionFilterBuilder ApplyFixAddedProfit(decimal amount)
	{
		return AddFilter(new FixAddedProfit(amount));
	}
	public IConditionFilterBuilder ApplyFixAmountDiscount(decimal amountOfDiscount)
	{
		return AddFilter(new FixAmountDiscount(amountOfDiscount, _actualPrice.Value));
	}

	public IConditionFilterBuilder ApplyPercentDiscount(decimal percentAmountOfDiscount)
	{
		return AddFilter(new PercentDiscount(percentAmountOfDiscount, _actualPrice.Value));
	}

	public IConditionFilterBuilder ThrowError(string message)
	{
		throw new NotImplementedException();
	}


	public IOperationFilterBuilder AnyOrder()
	{
		_currentCondition = new AnyOrder();
		return this;
	}

	public IOperationFilterBuilder WhenProductActualPriceMoreThan(decimal amount)
	{
		_currentCondition = new ProductActualPriceMoreThanAmount(amount);
		return this;
	}

	public IOperationFilterBuilder WhenSpecialCustomer()
	{
		_currentCondition = new SpecialCustomerCondition();
		return this;
	}

	private IConditionFilterBuilder AddFilter(IOperation operation)
	{
		var filter = new Filter(_currentCondition, operation);
		_filters.Add(filter);
		return this;
	}

	public IFilter Build()
	{
		if (_filters.Count == 0)
		{
			return EndFilter.Instance;
		}

		_filters.Aggregate((a, b) =>
		{
			a.SetNextFilter(b);
			return b;
		});

		return _filters.First();
	}
}

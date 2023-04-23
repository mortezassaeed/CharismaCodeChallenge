using Charisma.Framework.Domain.CommonValueObject;

namespace Charisma.Pricing.Application.PipeAndFilter.Conditions;

internal class SpecialCustomerCondition : ICondition
{
	private IReadOnlyList<int> _specialCustomer;
	public SpecialCustomerCondition()
	{
		_specialCustomer = new List<int>() { 1, 5, 10 }.AsReadOnly();
	}

	public bool IsSatisfiedBy(int customerId, Price actualPrice)
	{
		//TODO : In a real-life application, we should call customer service and ask if this customer is a special customer
		return _specialCustomer.Contains(customerId);
	}
}

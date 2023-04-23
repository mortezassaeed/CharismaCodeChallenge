using Charisma.Framework.Domain.CommonValueObject;

namespace Charisma.Pricing.Application.PipeAndFilter.Conditions;

internal class AnyOrder : ICondition
{
	public AnyOrder()
	{


	}


	public bool IsSatisfiedBy(int customerId, Price actualPrice) => true;

}

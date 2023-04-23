using Charisma.Framework.Domain.CommonValueObject;

namespace Charisma.Pricing.Application.PipeAndFilter.Conditions;

internal interface ICondition
{
	bool IsSatisfiedBy(int customerId, Price actualPrice);
}
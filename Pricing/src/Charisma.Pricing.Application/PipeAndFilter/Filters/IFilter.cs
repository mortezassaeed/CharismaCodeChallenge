using Charisma.Framework.Domain.CommonValueObject;

namespace Charisma.Pricing.Application.PipeAndFilter.Filters;

public interface IFilter
{
	Price Apply(int customerNo, Price actualPrice, Price finalPrice);
	void SetNextFilter(IFilter filter);
}

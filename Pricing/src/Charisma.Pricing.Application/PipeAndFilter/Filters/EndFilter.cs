using Charisma.Framework.Domain.CommonValueObject;

namespace Charisma.Pricing.Application.PipeAndFilter.Filters;

// null object
internal class EndFilter : IFilter
{

	public static IFilter Instance = new EndFilter();

	private EndFilter()
	{
	}

	public Price Apply(int customerNo, Price actualPrice, Price price)
	{
		return price;
	}

	public void SetNextFilter(IFilter filter)
	{
		throw new NotSupportedException();
	}
}


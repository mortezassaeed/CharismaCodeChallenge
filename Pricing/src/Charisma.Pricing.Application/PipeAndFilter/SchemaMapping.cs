using Charisma.Framework.Domain.CommonValueObject;
using Charisma.Pricing.Application.PipeAndFilter.Builders;
using Charisma.Pricing.Application.PipeAndFilter.Filters;

namespace Charisma.Pricing.Application.PipeAndFilter;


public class UserRegister
{

}

public class UserRegisterMapping : SchemaMapping<UserRegister>
{
	protected override void Configure(IFilterBuilder builder)
	{
		throw new NotImplementedException();
	}
}


public abstract class SchemaMapping<T>
{
	public IFilter CreateFilter(int customerId, Price actualPrice)
	{
		FilterBuilder builder = CreateFilterBuilder(customerId, actualPrice);
		Configure(builder);
		return builder.Build();
	}

	private FilterBuilder CreateFilterBuilder(int customerId, Price actualPrice)
	{
		return new FilterBuilder(customerId,actualPrice);
	}

	protected abstract void Configure(IFilterBuilder builder);
}


//.AnyOrder().ApplyFixAddedProfit(1000)
//			.WhenProductActualPriceMoreThan(2000).ApplyPercentDiscount(1)
//			.WhenSpecialCustomer().ApplyFixAmountDiscount(100)


//public class InlineSchemaMapping<T> : SchemaMapping<T>
//{
//	private readonly Action<IFilterBuilder> _configure;
//	public InlineSchemaMapping(Action<IFilterBuilder> configuration)
//	{
//		_configure = configuration;
//	}

//	protected override void Configure(IFilterBuilder builder)
//	{
//		_configure(builder);
//	}
//}




using Charisma.Framework.Domain.Concrete;

namespace Charisma.Framework.Domain.CommonValueObject;

public class Price : ValueObject
{
	public decimal Value { get; set; }
	public CurrencyType CurrencyType { get; set; } = CurrencyType.IRR;

	public Price(decimal value)
	{
		Value = value;
	}

	public Price(decimal value, CurrencyType currencyType) : this(value) 
	{
		CurrencyType = currencyType;
	}

}

public enum CurrencyType
{
	IRR,
	Euro,
	Dollar,
}

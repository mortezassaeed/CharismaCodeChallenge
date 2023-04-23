using Charisma.Framework.Domain.CommonValueObject;

namespace Charisma.Pricing.Application.PipeAndFilter.Operations;

internal interface IOperation
{
	Price Apply(Price price);

}

public class EventMappingException : Exception
{

	public EventMappingException(string message) : base(message) { }

}


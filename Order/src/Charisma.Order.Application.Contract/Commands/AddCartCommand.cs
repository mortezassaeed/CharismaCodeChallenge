using Charisma.Framework.Application;
using Charisma.Framework.Base;
using Charisma.Order.Domain.CartAggregate;

namespace Charisma.Order.Application.Contract.Commands;

public class AddCartCommand : ICommand
{
	public int CustomerId { get; set; }

	public List<int> ProductIds { get; set; }

	public AddCartCommand(int customerId, List<int> productIds)
	{
		CustomerId = customerId;
		ProductIds = productIds;
	}
}
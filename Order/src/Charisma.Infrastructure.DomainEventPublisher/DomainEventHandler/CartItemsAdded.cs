using Charisma.Framework.Domain.DomainEvents;
using Charisma.Order.Domain.Contracts.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Infrastructure.DomainEventPublisher.DomainEventHandler;

internal class CartItemsAddedEventHandler : IEventHandler<CartItemsAdded>
{
	public void Handle(CartItemsAdded domainEvent)
	{
		throw new NotImplementedException();
	}
}

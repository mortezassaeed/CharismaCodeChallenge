using Charisma.Framework.Application;
using Charisma.Framework.Application.Configurations;
using Charisma.Order.Application.Contract.Commands;
using Charisma.Order.Domain.CartAggregate;
using Charisma.Order.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Order.Application.CommandHandler;

public class AddCartCommandHandler : ICommandHandler<AddCartCommand>
{
	private readonly ICartRepository _repository;
	private readonly IClock _clock;

	public AddCartCommandHandler(ICartRepository repository, IClock clock)
	{
		_repository = repository;
		_clock = clock;
	}

	public async Task HandleAsync(AddCartCommand command)
	{
		if (command.ProductIds == null || command.ProductIds.Count == 0)
		{
			throw new CartItemIsEmptyException();
		}
		var cart = command.ToCart(_clock);
		await _repository.CreateAsync(cart);
	}
}

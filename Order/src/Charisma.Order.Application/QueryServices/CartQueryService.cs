using Charisma.Order.Application.Contract.QueryServices;
using Charisma.Order.Application.Contract.QueryServices.DTOs;
using Charisma.Order.Domain.CartAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Order.Application.QueryServices;

public class CartQueryService : ICartItemQueryService
{
	private readonly ICartRepository _repository;

	public CartQueryService(ICartRepository repository)
	{
		_repository = repository;
	}

	public async Task<CartDto> Get(Guid id)
	{
		var data = await _repository.GetByIdAsync(id);
		return data.ToCartDto();
	}
}

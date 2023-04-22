using Charisma.Order.Application.Contract.QueryServices.DTOs;

namespace Charisma.Order.Application.Contract.QueryServices;

public interface ICartItemQueryService
{
	Task<CartDto> Get(Guid id);
}
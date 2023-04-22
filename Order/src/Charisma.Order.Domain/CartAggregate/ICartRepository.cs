using Charisma.Framework.Domain.Interfaces;

namespace Charisma.Order.Domain.CartAggregate;


public interface ICartRepository : IRepository<Cart, Guid>
{

}


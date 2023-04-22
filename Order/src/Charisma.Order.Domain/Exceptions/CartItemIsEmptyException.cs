using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Order.Domain.Exceptions;

public class CartItemIsEmptyException : Exception
{
    public CartItemIsEmptyException() : base("You should add at least one item to your cart.") { }
}
    
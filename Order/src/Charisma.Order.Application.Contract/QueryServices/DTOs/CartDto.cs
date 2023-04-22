using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Order.Application.Contract.QueryServices.DTOs;

public class CartDto
{
	public Guid Id { get; set; }
	public int CustomerId { get; set; }
	public List<CartItemDto> Items { get; set; }
}
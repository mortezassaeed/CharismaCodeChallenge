using Charisma.Framework.Application.Configurations;
using Charisma.Order.Application.CommandHandler;
using Charisma.Order.Application.Tests.Unit.TestDoubles;
using Charisma.Order.Application.Tests.Unit.Utility;
using Charisma.Order.Domain.CartAggregate;
using Charisma.Order.Domain.Exceptions;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Charisma.Order.Application.Tests.Unit;

public class CartTest
{
	private readonly ICartRepository repo = Substitute.For<ICartRepository>();
	private IClock inTime = new ClockStubInTime();
	private IClock outOfTime = new ClockStubOutOfTime();
	private static List<int> EmptyItem = new List<int>();

	[Fact]
	public async Task Cart_should_create_with_valid_data()
	{	
		var cartCommand = new Contract.Commands.AddCartCommand(
			FakeCustomer.ValidCustomer, 
				new List<int> { 1, 2 });

		AddCartCommandHandler handler = new AddCartCommandHandler(repo, inTime);
		await handler.HandleAsync(cartCommand);

		await repo.Received().CreateAsync(Arg.Any<Cart>());
	}

	[Fact]
	public async Task Cart_should_not_be_created_out_of_forbidding_time()
	{
		var cartCommand = new Contract.Commands.AddCartCommand(FakeCustomer.ValidCustomer, new List<int> { 1, 2 });

		AddCartCommandHandler handler = new AddCartCommandHandler(repo, outOfTime);
		var handlerDelegate = async () =>  await handler.HandleAsync(cartCommand) ;

		await handlerDelegate.Should().ThrowAsync<CartOutOfPossibleTime>();
	}

	[Fact]
	public async Task Cart_should_not_create_without_customer()
	{
		var cartCommand = new Contract.Commands.AddCartCommand(FakeCustomer.InValidCustomer, new List<int> { 1, 2 });

		AddCartCommandHandler handler = new AddCartCommandHandler(repo, inTime);
		var handlerDelegate = async () => await handler.HandleAsync(cartCommand);

		await handlerDelegate.Should().ThrowAsync<CartCustomerIsRequired>();
	}

	[Theory]
	[InlineData(null)]
	[InlineData(new int[] { })]
	public async Task Cart_should_not_create_without_item(int[] items)
	{
		var cartCommand = new Contract.Commands.AddCartCommand(FakeCustomer.ValidCustomer, items?.ToList());

		AddCartCommandHandler handler = new AddCartCommandHandler(repo, inTime);
		var handlerDelegate = async () => await handler.HandleAsync(cartCommand);

		await handlerDelegate.Should().ThrowAsync<CartItemIsEmptyException>();
	}
}
using Charisma.Framework.Application.Configurations;
using Charisma.Framework.Application.Configurations.Communicate;
using Charisma.Order.Application.CommandHandler;
using Charisma.Order.Application.ServiceCommunicate;
using Charisma.Order.Application.Tests.Unit.TestDoubles;
using Charisma.Order.Application.Tests.Unit.Utility;
using Charisma.Order.Domain.CartAggregate;
using Charisma.Order.Domain.Exceptions;
using FluentAssertions;
using NSubstitute;

namespace Charisma.Order.Application.Tests.Unit;

public class CartTest
{
	private readonly ICartRepository cartRepo = Substitute.For<ICartRepository>();
	private IClock inTime = new ClockStubInTime();
	private IClock outOfTime = new ClockStubOutOfTime();
	private IProductRepository productRepo = new ProductRepositoryStub();
	private ICommunicateService<GetProductPriceResponse, GetProductPriceRequest> igRPCService = new FakeCommunicateService();
	private readonly ICommunicateService<ProductSubmissionRequest> _submissionService = new FakeSubmissionCommunicateService();

	[Fact]
	public async Task Cart_should_create_with_valid_data()
	{
		var cartCommand = new Contract.Commands.AddCartCommand(
			FakeCustomer.ValidCustomer,
				new List<int> { 1 });

		AddCartCommandHandler handler = new AddCartCommandHandler(cartRepo, inTime, igRPCService, productRepo, _submissionService);
		await handler.HandleAsync(cartCommand);

		await cartRepo.Received().CreateAsync(Arg.Any<Cart>());
	}

	[Fact]
	public async Task Cart_should_not_be_created_out_of_forbidding_time()
	{
		var cartCommand = new Contract.Commands.AddCartCommand(FakeCustomer.ValidCustomer, new List<int> { 1 });

		AddCartCommandHandler handler = new AddCartCommandHandler(cartRepo, outOfTime, igRPCService, productRepo, _submissionService);
		var handlerDelegate = async () => await handler.HandleAsync(cartCommand);

		await handlerDelegate.Should().ThrowAsync<CartOutOfPossibleTime>();
	}

	[Fact]
	public async Task Cart_should_not_create_without_customer()
	{
		var cartCommand = new Contract.Commands.AddCartCommand(FakeCustomer.InValidCustomer, new List<int> { 1 });

		AddCartCommandHandler handler = new AddCartCommandHandler(cartRepo, inTime, igRPCService, productRepo, _submissionService);
		var handlerDelegate = async () => await handler.HandleAsync(cartCommand);

		await handlerDelegate.Should().ThrowAsync<CartCustomerIsRequired>();
	}

	[Theory]
	[InlineData(null)]
	[InlineData(new int[] { })]
	public async Task Cart_should_not_create_without_item(int[] items)
	{
		var cartCommand = new Contract.Commands.AddCartCommand(FakeCustomer.ValidCustomer, items?.ToList());

		AddCartCommandHandler handler = new AddCartCommandHandler(cartRepo, inTime, igRPCService, productRepo, _submissionService);
		var handlerDelegate = async () => await handler.HandleAsync(cartCommand);

		await handlerDelegate.Should().ThrowAsync<CartItemIsEmptyException>();
	}

	[Fact]
	public async Task Sum_of_cart_price_should_be_less_than_50000()
	{
		var cartCommand = new Contract.Commands.AddCartCommand(FakeCustomer.ValidCustomer, new List<int> { 1, 2 });

		AddCartCommandHandler handler = new AddCartCommandHandler(cartRepo, inTime, igRPCService, productRepo, _submissionService);
		var handlerDelegate = async () => await handler.HandleAsync(cartCommand);

		await handlerDelegate.Should().ThrowAsync<SumOfProductPriceIsLessThanAllowed>();
	}
}
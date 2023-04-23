using Charisma.Framework.Application;
using Charisma.Framework.Application.Configurations;
using Charisma.Framework.Application.Configurations.Communicate;
using Charisma.Order.Application.Contract.Commands;
using Charisma.Order.Application.ServiceCommunicate;
using Charisma.Order.Domain.CartAggregate;
using Charisma.Order.Domain.Exceptions;

namespace Charisma.Order.Application.CommandHandler;

public class AddCartCommandHandler : ICommandHandler<AddCartCommand>
{
	private readonly ICartRepository _repository;
	private readonly IClock _clock;
	private readonly ICommunicateService<GetProductPriceResponse, GetProductPriceRequest> _pricingService;
	private readonly IProductRepository _productRepository;
	public AddCartCommandHandler(ICartRepository repository,
		IClock clock,
		ICommunicateService<GetProductPriceResponse, GetProductPriceRequest> pricingService,
		IProductRepository productRepository)
	{
		_repository = repository;
		_clock = clock;
		_pricingService = pricingService;
		_productRepository = productRepository;
	}

	public async Task HandleAsync(AddCartCommand command)
	{
		if (command.ProductIds == null || command.ProductIds.Count == 0)
		{
			throw new CartItemIsEmptyException();
		}

		var cart = command.ToCart(_clock);
		var products = await _productRepository.GetAll(x => command.ProductIds.Contains(x.Id));

		foreach (var p in command.ProductIds)
		{
			var productCode = products.First(m => m.Id == p).ProductCode;
			var pricingResult = await _pricingService.GetData(new GetProductPriceRequest(productCode, command.CustomerId));
			cart.CartItems.First(i => i.ProductId == p).AddPrice(new Framework.Domain.CommonValueObject.Price(pricingResult.Price));
		}

		if (cart.CartItems.Sum(m => m.Price.Value) > 50000)
		{
			throw new SumOfProductPriceIsLessThanAllowed();
		}

		await _repository.CreateAsync(cart);
	}
}

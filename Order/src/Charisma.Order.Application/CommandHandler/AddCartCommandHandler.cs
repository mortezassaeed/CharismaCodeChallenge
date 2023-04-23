using Charisma.Framework.Application;
using Charisma.Framework.Application.Configurations;
using Charisma.Framework.Application.Configurations.Communicate;
using Charisma.Order.Application.Contract.Commands;
using Charisma.Order.Application.ServiceCommunicate;
using Charisma.Order.Domain.CartAggregate;
using Charisma.Order.Domain.Exceptions;
using Charisma.Order.Domain.ProductAggregate;

namespace Charisma.Order.Application.CommandHandler;

public class AddCartCommandHandler : ICommandHandler<AddCartCommand>
{
	private readonly ICartRepository _repository;
	private readonly IClock _clock;
	private readonly ICommunicateService<GetProductPriceResponse, GetProductPriceRequest> _pricingService;
	private readonly ICommunicateService<ProductSubmissionRequest> _submissionService;
	private readonly IProductRepository _productRepository;
	public AddCartCommandHandler(ICartRepository repository,
		IClock clock,
		ICommunicateService<GetProductPriceResponse, GetProductPriceRequest> pricingService,
		IProductRepository productRepository,
		ICommunicateService<ProductSubmissionRequest> submissionService)
	{
		_repository = repository;
		_clock = clock;
		_pricingService = pricingService;
		_productRepository = productRepository;
		_submissionService = submissionService;
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


		foreach (var p in command.ProductIds)
		{
			var productCode = products.First(m => m.Id == p).ProductCode;
			await _submissionService.GetData(new ProductSubmissionRequest(productCode, cart.Id ));
		}
	}
}

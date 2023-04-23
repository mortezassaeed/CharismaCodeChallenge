using Charisma.Framework.Application.Configurations.Communicate;

namespace Charisma.Order.Application.ServiceCommunicate;

public class FakeCommunicateService : ICommunicateService<GetProductPriceResponse, GetProductPriceRequest>
{

	private IReadOnlyDictionary<string, decimal> productPriceDic;
	public FakeCommunicateService()
	{
		productPriceDic = new Dictionary<string, decimal>()
		{
			["P_1"] = 10000m,
			["P_2"] = 50000m
		}.AsReadOnly();
	}

	public async Task<GetProductPriceResponse> GetData(GetProductPriceRequest request)
	{
		// TODO : implement real gRPC service to communicate with pricing service with real important parameters
		if (!productPriceDic.TryGetValue(request.ProductCode, out var price))
		{

			throw new Exception("Product is not defined");
		}
		return await Task.FromResult(new GetProductPriceResponse(request.ProductCode, price));
	}
}


public class FakeSubmissionCommunicateService : ICommunicateService<ProductSubmissionRequest>
{
	public async Task GetData(ProductSubmissionRequest request)
	{
		await Task.CompletedTask;
	}
}
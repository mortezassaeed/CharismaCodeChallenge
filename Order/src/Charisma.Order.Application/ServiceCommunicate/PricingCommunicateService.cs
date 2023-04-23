using Charisma.Framework.Application.Configurations.Communicate;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Charisma.Order.Application.ServiceCommunicate;

public class PricingCommunicateService : ICommunicateService<GetProductPriceResponse, GetProductPriceRequest>
{

	private readonly IConfiguration _configuration;

	public PricingCommunicateService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public async Task<GetProductPriceResponse> GetData(GetProductPriceRequest request)
	{
		var serviceAddress = _configuration.GetSection("ExternalServices:Pricing").Value;
		using var client = new RestClient(serviceAddress!);
		var restRequest = new RestRequest("api/pricing", Method.Post);
		restRequest.AddBody(request);
		var response = await client.ExecuteAsync<GetProductPriceResponse>(restRequest);

		return response.Data!;
	}
}

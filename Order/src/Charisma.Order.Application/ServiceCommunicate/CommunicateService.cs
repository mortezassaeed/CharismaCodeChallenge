using Charisma.Framework.Application.Configurations.Communicate;
using RestSharp;

namespace Charisma.Order.Application.ServiceCommunicate;

public class CommunicateService : ICommunicateService<GetProductPriceResponse, GetProductPriceRequest>
{

	public async Task<GetProductPriceResponse> GetData(GetProductPriceRequest request)
	{
		using var client = new RestClient("https://localhost:7293");
		var restRequest = new RestRequest("api/pricing", Method.Post);
		restRequest.AddBody(request);
		var response = await client.ExecuteAsync<GetProductPriceResponse>(restRequest);

		return response.Data!;
	}
}

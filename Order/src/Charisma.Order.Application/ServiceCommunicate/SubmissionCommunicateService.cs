using Charisma.Framework.Application.Configurations.Communicate;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Charisma.Order.Application.ServiceCommunicate;
public class SubmissionCommunicateService : ICommunicateService<ProductSubmissionRequest>
{
	private readonly IConfiguration _configuration;

	public SubmissionCommunicateService(IConfiguration configuration)
	{
		_configuration = configuration;
	}
	public async Task GetData(ProductSubmissionRequest request)
	{
		var serviceAddress = _configuration.GetSection("ExternalServices:Submission").Value;
		using var client = new RestClient(serviceAddress!);
		
		var restRequest = new RestRequest("api/SubmissionOrder", Method.Post);
		restRequest.AddBody(request);
		var response = await client.ExecuteAsync(restRequest);
	}
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Charisma.Submission.Application;
using Charisma.Submission.Infra.SQLEF;

namespace SubmissionConfig;

public static class ServiceExtension
{
	public static void UseSubmission(this IServiceCollection services, IConfiguration configuration)
	{
		services.UseSubmissionEFDataAccess(configuration);
		services.UseSubmissionServices();
	}

}

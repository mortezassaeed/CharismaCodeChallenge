using Charisma.Framework.Application;
using Charisma.Framework.Application.Configurations;
using Charisma.Submission.Application.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace Charisma.Submission.Application;

public static class ServiceExtension
{
	public static void UseSubmissionServices(this IServiceCollection services)
	{
		services.UseCommandAndHandler();

		services.Scan(scan => scan
			.FromAssemblyOf<SubmitOrderCommandHandler>()
				.AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
					.AsImplementedInterfaces()
					.WithSingletonLifetime());
	}
}

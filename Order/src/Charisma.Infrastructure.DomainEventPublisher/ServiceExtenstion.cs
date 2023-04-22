using Microsoft.Extensions.DependencyInjection;

namespace Charisma.Infrastructure.Persistence.SQLEF;

public static class ServiceExtension
{
	public static void UseOrderEFDataAccess(this IServiceCollection services)
	{

		//services.Scan(scan => scan
		//			.FromAssemblyOf<BidPlacedHandler>()
		//				.AddClasses(classes => classes.AssignableTo(typeof(IEventHandler<>)))
		//					.AsImplementedInterfaces()
		//					.WithSingletonLifetime());

	}
}

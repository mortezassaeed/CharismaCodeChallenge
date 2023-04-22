using Charisma.Framework.Application;
using Charisma.Framework.Application.Configurations;
using Charisma.Order.Application.CommandHandler;
using Charisma.Order.Application.Contract.QueryServices;
using Charisma.Order.Application.QueryServices;
using Microsoft.Extensions.DependencyInjection;

namespace Charisma.Order.Application;

public static class ServiceExtension
{
	public static void UseOrderServices(this IServiceCollection services)
	{
		services.UseCommandAndHandler();

		services.Scan(scan => scan
			.FromAssemblyOf<AddCartCommandHandler>()
				.AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
					.AsImplementedInterfaces()
					.WithSingletonLifetime());

		services.AddSingleton<ICartItemQueryService, CartQueryService>();

	}
}

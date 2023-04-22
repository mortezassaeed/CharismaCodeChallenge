using Microsoft.Extensions.DependencyInjection;

namespace Charisma.Framework.Application.Configurations.Commands;

internal class CommandBus : ICommandBus
{
	private readonly IServiceProvider serviceProvider;

	public CommandBus(IServiceProvider serviceProvider)
	{
		this.serviceProvider = serviceProvider;
	}

	public async Task DispatchAsync<T>(T command) where T : ICommand
	{
		var commandHandler = serviceProvider.GetRequiredService<ICommandHandler<T>>();
		await commandHandler.HandleAsync((dynamic)command);
	}
}

namespace Charisma.Framework.Application;

public interface ICommandBus
{
	Task DispatchAsync<T>(T command) where T : ICommand;
}
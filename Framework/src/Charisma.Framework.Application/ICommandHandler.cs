namespace Charisma.Framework.Application;

public interface ICommandHandler<T> where T : ICommand
{
	Task HandleAsync(T command);
}
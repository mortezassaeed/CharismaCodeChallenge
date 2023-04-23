namespace Charisma.Framework.Application.Configurations.Communicate;

public interface ICommunicateService<TResponse, TRequest>
{
	Task<TResponse> GetData(TRequest request);
}


public interface ICommunicateService<TRequest>
{
	Task GetData(TRequest request);
}

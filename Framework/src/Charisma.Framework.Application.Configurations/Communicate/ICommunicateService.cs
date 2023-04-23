namespace Charisma.Framework.Application.Configurations.Communicate
{
	public interface ICommunicateService<TResponse, TRequest>
	{
		Task<TResponse> GetData(TRequest request);
	}
}

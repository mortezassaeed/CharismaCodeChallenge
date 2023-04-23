using Charisma.Framework.Application;
using Charisma.Submission.Application.Contracts.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Charisma.Presentation.WebAPI;

[ApiController]
[Route("api/[controller]")]
public class SubmissionOrderController : ControllerBase
{
	private readonly ICommandBus _commandBus;

	public SubmissionOrderController(ICommandBus commandBus)
	{
		_commandBus = commandBus;
	}
	[HttpPost]
	public async Task<IActionResult> Post(SubmitOrderCommand command)
	{
		await _commandBus.DispatchAsync(command);
		return Ok();
	}
}

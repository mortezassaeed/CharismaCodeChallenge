using Charisma.Framework.Application;
using Charisma.Submission.Application.Contracts.Commands;
using Charisma.Submission.Domain.ProductAggregate;
using Charisma.Submission.Domain.SubmissionAggregate;
using Charisma.Submission.Domain.SubmissionAggregate.Services;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Charisma.Submission.Application.CommandHandlers;

internal class SubmitOrderCommandHandler : ICommandHandler<SubmitOrderCommand>
{
	private readonly IProductRepository _productRepository;
	private readonly IConfiguration _configuration;
	private readonly IOrderSubmissionRepository _orderSubmissionRepository;

	public SubmitOrderCommandHandler(
		IProductRepository productRepository,
		IConfiguration configuration,
		IOrderSubmissionRepository orderSubmissionRepository)
	{
		_productRepository = productRepository;
		_configuration = configuration;
		_orderSubmissionRepository = orderSubmissionRepository;
	}

	public async Task HandleAsync(SubmitOrderCommand command)
	{
		var product = await _productRepository.GetAsync(x => x.ProductCode == command.ProductCode);
		var strSubmissionType= _configuration.GetSection($"SubmissionTypes:{product.Type}").Value;
		var submissionType = SubmissionService.GetSubmissionType(strSubmissionType);

		var SubmitOrder = new OrderSubmission(command.OrderNo, submissionType, product!.Id);
		await _orderSubmissionRepository.CreateAsync(SubmitOrder);
	}
}

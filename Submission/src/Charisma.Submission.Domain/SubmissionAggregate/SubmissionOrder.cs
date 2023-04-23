using Charisma.Framework.Domain.Concrete;
using Charisma.Submission.Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Submission.Domain.SubmissionAggregate;

public class OrderSubmission : AggregateRoot<int>
{
	public Guid OrderNo { get; set; }
	public SubmissionType SubmissionType { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
	public OrderSubmission(Guid orderNo, SubmissionType submissionType, int productId)
	{
		OrderNo = orderNo;
		SubmissionType = submissionType;
		ProductId = productId;
	}
}

using Charisma.Framework.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Submission.Domain.SubmissionAggregate;

public interface IOrderSubmissionRepository : IRepository<OrderSubmission,int>
{
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Charisma.Submission.Domain.SubmissionAggregate.Services;

public class SubmissionService
{
	public static SubmissionType GetSubmissionType(string strType) =>
		 (SubmissionType)Enum.Parse(typeof(SubmissionType), strType); 


}

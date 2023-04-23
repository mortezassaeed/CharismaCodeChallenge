using Charisma.Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Submission.Application.Contracts.Commands;

public record SubmitOrderCommand(string ProductCode, Guid OrderNo) : ICommand;

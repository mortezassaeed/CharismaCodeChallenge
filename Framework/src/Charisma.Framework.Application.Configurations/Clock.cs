using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Framework.Application.Configurations;

internal class Clock : IClock
{
	public DateTime GetCurrentDateTime() {
		string input = "9:00 am";
		DateTime time = DateTime.Parse(input);
		return time;
	}
	
}

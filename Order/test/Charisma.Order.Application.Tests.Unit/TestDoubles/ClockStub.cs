using Charisma.Framework.Application.Configurations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Order.Application.Tests.Unit.TestDoubles;

internal class ClockStubInTime : IClock
{
	public DateTime GetCurrentDateTime()
	{
		string input = "9:00 am";
		DateTime time = DateTime.Parse(input);
		return time;
	}
}


internal class ClockStubOutOfTime : IClock
{
	public DateTime GetCurrentDateTime()
	{
		var now = DateTime.Now;
		DateTime newTime = new DateTime(now.Year, now.Month, now.Day, 21, 0, 0); // set the time to 10:30 AM
		return newTime;
	}
}
using System;

namespace Payroll
{
	public class WeeklySchedule
	{
		public bool IsPAyDate(DateTime payDate)
		{
			return payDate.DayOfWeek == DayOfWeek.Friday;
		}
	}
}
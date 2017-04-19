using System;

namespace Payroll
{
	public class TimeCard
	{
		public TimeCard(DateTime date, double hours)
		{
			this.Date = date;
			this.Hours = hours;
		}

		public double Hours { get; }
		public DateTime Date { get; }
	}
}
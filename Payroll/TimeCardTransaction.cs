using System;

namespace Payroll
{
	public class TimeCardTransaction : TimeCard, ITransaction
	{
		private readonly DateTime _date;
		private readonly double _hours;
		private readonly int _empid;

		public TimeCardTransaction(DateTime date, double hours, int empid) :base(date, hours)
		{
			_empid = empid;
			_date = date;
			_hours = hours;
		}

		public void Execute()
		{
			var e = PayrollDatabase.GetEmployee(_empid);

			if (e != null)
			{
				var hc = e.Classification as HourlyClassification;
				if (hc != null)
					hc.AddTimeCard(new TimeCard(_date, _hours));
				else
					throw new InvalidOperationException("Tried to add timecard to " + "non-hourly employee");
			}
			else
				throw new InvalidOperationException("No such employee");
			
		}
	}
}
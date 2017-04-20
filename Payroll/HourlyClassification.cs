using System;

namespace Payroll
{
	public class HourlyClassification : PaymentClassification
	{
		private readonly double _hourlyRate;

		public HourlyClassification(double hourlyRate)
		{
			this._hourlyRate = hourlyRate;
		}
		
		

		public double Salary => _hourlyRate * 8.0;
		public double HourlyRate { get; set; }

		public void AddTimeCard(TimeCard timeCard)
		{
			new TimeCard(timeCard.Date,timeCard.Hours);
		}

		public TimeCard GetTimeCard(DateTime dateTime)
		{
			return new TimeCard(dateTime, 8.0 );
		}
	}
}
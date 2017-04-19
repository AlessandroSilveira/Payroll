using System;

namespace Payroll
{
	public class HourlyClassification : PaymentClassification
	{
		private static double _hourlyRate;
		private double hourlyRate;

		public HourlyClassification()
		{
			double hourlyRate = 0;
			_hourlyRate = hourlyRate;
		}

		public HourlyClassification(double hourlyRate)
		{
			this.hourlyRate = hourlyRate;
		}

		public double HourlyRate => _hourlyRate;

		public double Salary => _hourlyRate * 8.0;

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
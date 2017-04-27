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
		
		public double CaculatePay(PayCheck payCheck)
		{
			double totalPay = 0.0;
			foreach (TimeCard timeCard in timeCards.Values)
			{
				if (IsInPayPeriod(timeCard, payCheck.PayDate))
					totalPay += CalculatePayForTimeCard(timeCard);
			}
			return totalPay;
		}

		private bool IsInPayPeriod(TimeCard card, DateTime payPeriod)
		{
			DateTime payPeriodEndDate = payPeriod;
			DateTime payPeriodStartDate = payPeriod.AddDays(-5);

			return card.Date <= payPeriodEndDate && card.Date >= payPeriodStartDate;
		}

		private double CalculatePayForTimeCard(TimeCard card)
		{
			double overtimeHours = Math.Max(0.0, card.Hours - 8);
			double normalHours = card.Hours - overtimeHours;

			return HourlyRate * normalHours + HourlyRate * 1.5 * overtimeHours;
		}

	}
}
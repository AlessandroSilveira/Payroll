using System;

namespace Payroll
{
	public class ServiceCharge
	{
		public ServiceCharge(DateTime date, double amount)
		{
			Date = date;
			Amount = amount;
		}

		public DateTime Date { get; }

		public double Amount { get; }
	}
}
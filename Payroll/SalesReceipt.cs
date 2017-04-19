using System;

namespace Payroll
{
	public class SalesReceipt
	{
		public SalesReceipt(DateTime date, double amount)
		{
			this.Date = date;
			this.Amount = amount;
		}

		public DateTime Date { get; }

		public double Amount { get; }
	}
}

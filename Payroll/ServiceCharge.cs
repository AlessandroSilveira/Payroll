using System;

namespace Payroll
{
	public class ServiceCharge
	{
		private readonly double _amount;

		public ServiceCharge(DateTime date, double amount)
		{
			Date = date;
			_amount = amount;
		}

		public DateTime Date { get; }

		public double Amount => _amount;
	}
}
using System;

namespace Payroll
{
	public class PayCheck
	{
		public PayCheck(DateTime startDate, DateTime payDate)
		{
			throw new NotImplementedException();
		}

		public DateTime PayDate { get; set; }
		public double GrossPay { get; set; }
		public double Deductions { get; set; }
		public double NetPay { get; set; }
		public DateTime PayPeriodEndDate { get; set; }
		public DateTime PayPeriodStartDate { get; set; }

		public string GetField(string disposition)
		{
			throw new NotImplementedException();
		}
	}
}
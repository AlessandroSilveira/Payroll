using System;

namespace Payroll
{
	public class PayCheck
	{
		public PayCheck(DateTime payDate)
		{
			throw new NotImplementedException();
		}

		public DateTime PayDate { get; set; }
		public double GrossPay { get; set; }
		public double Deductions { get; set; }
		public double NetPay { get; set; }

		public string GetField(string disposition)
		{
			throw new NotImplementedException();
		}
	}
}
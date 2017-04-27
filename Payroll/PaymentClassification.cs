using System;

namespace Payroll
{
	public class PaymentClassification
	{
		public double CalculatePay(PayCheck payCheck)
		{
			throw new System.NotImplementedException();
		}

		public bool IsInPayPeriod(DateTime theDate, PayCheck paycheck)
		{
			DateTime payPeriodEndDate = paycheck.PayPeriodEndDate;
			DateTime payPeriodStartDate = paycheck.PayPeriodStartDate;
			return (theDate >= payPeriodStartDate) && (theDate <= payPeriodEndDate);
		}
	}
}
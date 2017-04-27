using System;

namespace Payroll
{
	public class UnionAffiliation : Affiliation
	{
		public int MemberId { get; }
		public double Dues { get; set; }

		public UnionAffiliation(int memberId, double dues)
		{
			MemberId = memberId;
			Dues = dues;
		}

		public UnionAffiliation()
		{
		}

		public ServiceCharge GetServiceCharge(DateTime dateTime, double charge)
		{
			return new ServiceCharge(DateTime.Now, charge);
		}

		public void AddServiceCharge(ServiceCharge serviceCharge)
		{
			 new ServiceCharge(serviceCharge.Date, serviceCharge.Amount);
		}

		public double CalculateDeductions(PayCheck payCheck)
		{
			double totalDues = 0;

			int fridays = NumberOfFridaysInPayPeriod(payCheck.PayPeriodStartDate, payCheck.PayPeriodEndDate);

			int dues = 0;
			totalDues = dues * fridays;
			return totalDues;
		}

		private int NumberOfFridaysInPayPeriod(DateTime payPeriodStart, DateTime payPeriodEnd)
		{
			int fridays = 0;
			for (DateTime day = payPeriodStart; day <= payPeriodEnd; day.AddDays(1))
			{
				if (day.DayOfWeek == DayOfWeek.Friday)
					fridays++;
			}
			return fridays;
		}

	}
}
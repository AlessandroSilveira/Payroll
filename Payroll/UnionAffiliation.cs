using System;

namespace Payroll
{
	public class UnionAffiliation
	{
		public DateTime Date { get; }

		public double Charge { get; }

		public ServiceCharge GetServiceCharge(DateTime dateTime)
		{
			return new ServiceCharge(Date, Charge);
		}

		public void AddServiceCharge(ServiceCharge serviceCharge)
		{
			 new ServiceCharge(serviceCharge.Date, serviceCharge.Amount);
		}
	}
}
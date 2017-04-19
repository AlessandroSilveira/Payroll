using System;

namespace Payroll
{
	public class UnionAffiliation
	{
		private readonly DateTime _date;
		private readonly double _amount;

		public DateTime Date => _date;
		public double Amount => _amount;

		public ServiceCharge GetServiceCharge(DateTime dateTime)
		{
			return new ServiceCharge(Date,Amount);
		}

		public void AddServiceCharge(ServiceCharge serviceCharge)
		{
			var charge = new ServiceCharge(serviceCharge.Date, serviceCharge.Amount);
		}
	}
}
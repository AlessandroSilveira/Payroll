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
	}
}
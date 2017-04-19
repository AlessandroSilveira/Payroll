using System;

namespace Payroll
{
	public class ServiceChargeTransaction : ITransaction
	{
		public ServiceChargeTransaction(DateTime time, int memberId, double amount)
		{
			Time = time;
			MemberId = memberId;
			Amount = amount;
		}

		public DateTime Time { get; }
		public int MemberId { get; }
		public double Amount { get; }

		public void Execute()
		{
			var e = PayrollDatabase.GetUnionMember(MemberId);

			if (e != null)
			{
				UnionAffiliation ua = null;
				ua = e.Affiliation as UnionAffiliation;
				if (ua == null)
					throw new InvalidOperationException("Tries to add service charge to union" + "Member without a union affiliation");
				else
					ua.AddServiceCharge(new ServiceCharge(Time, Amount));
			}
			else
				throw new InvalidOperationException("No such member");
		}
	}
}
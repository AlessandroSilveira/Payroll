using System;

namespace Payroll
{
	public class ServiceChargeTransaction : ITransaction
	{
		private readonly int _memberId;
		private readonly DateTime _time;
		private readonly double _charge;
		

		public ServiceChargeTransaction(DateTime time, int memberId, double charge)
		{
			_time = time;
			this._memberId = memberId;
			this._charge = charge;
		}


		public DateTime Time => _time;
		public int MemberId => _memberId;
		public double Charge => _charge;
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
					ua.AddServiceCharge(new ServiceCharge(Time, Charge));
			}
			else
				throw new InvalidOperationException("No such member");
			
		}
	}
}
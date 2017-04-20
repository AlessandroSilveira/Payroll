using System;

namespace Payroll
{
	public class ServiceChargeTransaction : ITransaction
	{
		private readonly int _memberId;
		private readonly DateTime _time;
		private readonly double _charge;
		

		public ServiceChargeTransaction(DateTime dateTime, int memberId, double charge)
		{
			this._time = dateTime;
			this._memberId = memberId;
			this._charge = charge;
		}

		public void Execute()
		{
			var e = PayrollDatabase.GetUnionMember(_memberId);

			if (e != null)
			{
				UnionAffiliation ua = null;
				if (e.Affiliation is UnionAffiliation)
					ua = e.Affiliation as UnionAffiliation;

				if (ua != null)
					ua.AddServiceCharge(new ServiceCharge(_time, _charge));
				else
				{
					throw new InvalidOperationException("Tries to add service charge to union" + "member without a union affiliation");
				}
			}
			else
			{
				throw new InvalidOperationException("No Such union member");
			}
		}
	}
}
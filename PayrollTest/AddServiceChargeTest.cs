using System;
using NUnit.Framework;
using Payroll;

namespace PayrollTest
{
	[TestFixture]
	public class AddServiceChargeTest
	{
		[Test]
		public void AddServiceCharge()
		{
			int empId = 2;

			var t = new AddHourlyEmployee(empId,"Bill","Home",15.25);
			t.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);

			var af = new UnionAffiliation();
			e.Affiliation = af;
			int memberId = 86;
			PayrollDatabase.AddUnionMember(memberId, e);
			var sct = new ServiceChargeTransaction(new DateTime(2017,04,19),memberId, 12.95);
			sct.Execute();

			var sc = af.GetServiceCharge(new DateTime(2017, 04, 19));
			Assert.IsNotNull(sc);
			Assert.AreEqual(12.95, sc.Amount, .001);

		}
	}
}
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

			AddHourlyEmployee t = new AddHourlyEmployee(empId,"Bill","Home",15.25);
			t.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);

			UnionAffiliation af = new UnionAffiliation();
			e.Affiliation = af;
			int memberId = 8;
			PayrollDatabase.AddUnionMember(memberId, e);
			ServiceChargeTransaction sct = new ServiceChargeTransaction(new DateTime(2017,04,19),memberId,12.95 );
			sct.Execute();

			ServiceCharge sc = af.GetServiceCharge(new DateTime(2017, 04, 19));
			Assert.IsNotNull(sc);
			Assert.AreEqual(12.95,sc.Amount,.001);

		}
	}
}
using NUnit.Framework;
using Payroll;

namespace PayrollTest
{
	[TestFixture]
	public class AddCommissionedEmployeeTest 
	{
		[Test]
		public void TestAddCommissionedEmployeetest()
		{
			var empId = 1;
			var t = new AddCommissionedEmployee(empId, "Kurt", "Home", 2000,3.2);
			t.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			Assert.AreEqual("Kurt", e.Name);

			var pc = e.Classification;
			Assert.IsTrue(pc is CommissionedClassification);
			var sc = pc as CommissionedClassification;
			Assert.AreEqual(6400, sc.Salary, .0001);
			var ps = e.Schedule;
			Assert.IsTrue(ps is BiweeklyScheddule);

			var pm = e.Method;
			Assert.IsTrue(pm is HoldMethod);

		}
	}
}
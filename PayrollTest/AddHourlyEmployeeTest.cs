using NUnit.Framework;
using Payroll;

namespace PayrollTest
{
	[TestFixture()]
	public class AddHourlyEmployeeTest
	{

		[Test]
		public void TestAddHourlyEmployeetest()
		{
			var empId = 1;
			var t =new AddHourlyEmployee(empId, "Ale", "Home", 15.35);
			t.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			Assert.AreEqual("Ale", e.Name);

			var pc = e.Classification;
			Assert.IsTrue(pc is HourlyClassification);
			var sc = pc as HourlyClassification;
			Assert.AreEqual(122.8, sc.Salary, .0001);
			var ps = e.Schedule;
			Assert.IsTrue(ps is BiweeklyScheddule);

			var pm = e.Method;
			Assert.IsTrue(pm is HoldMethod);

		}
	}
}
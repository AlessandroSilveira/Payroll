using NUnit.Framework;
using Payroll;
using Assert = NUnit.Framework.Assert;

namespace PayrollTest
{
	[TestFixture]
	public class TestAddSalariedEmployee
	{
		[Test]
		public void TestAddSalariedEmployeetest()
		{
			var empId = 1;
			var t = new AddSalariedEmployee(empId,"Bob","Home",1000.00);
			t.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			Assert.AreEqual("Bob",e.Name);

			var pc = e.Classification;
			Assert.IsTrue(pc is SalariedClassification);
			var sc = pc as SalariedClassification;
			Assert.AreEqual(1000.00, sc.Salary,.001);
			var ps = e.Schedule;
			Assert.IsTrue(ps is MonthlySchedule);

			var pm = e.Method;
			Assert.IsTrue(pm is HoldMethod);

		}
	}
}

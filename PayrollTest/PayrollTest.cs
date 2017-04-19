using NUnit.Framework;
using Payroll;

namespace PayrollTest
{
	[TestFixture]
	public class PayrollTest
	{
		[Test]
		public void TestAddCommissionedEmployeetest()
		{
			var empId = 1;
			var t = new AddCommissionedEmployee(empId, "Kurt", "Home", 2000, 3.2);
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

		[Test]
		public void TestAddHourlyEmployeetest()
		{
			var empId = 1;
			var t = new AddHourlyEmployee(empId, "Ale", "Home", 15.35);
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

		[Test]
		public void TestChangeHourlyTransaction()
		{
			int empId = 3;

			AddCommissionedEmployee t = new AddCommissionedEmployee(empId,"Lance","Home",2500,3.2);
			t.Execute();

			var cht = new ChangeHourlyTransaction(empId, 27.52);
			cht.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);
			PaymentClassification pc = e.Classification;
			Assert.IsNotNull(pc);
			Assert.IsTrue(pc is HourlyClassification);
			HourlyClassification hc = pc as HourlyClassification;
			Assert.AreEqual(27.52, hc.HourlyRate, .001);
			PaymentSchedule ps = e.Schedule;
			Assert.IsTrue(ps is WeeklySchedule);

		}
	}
}
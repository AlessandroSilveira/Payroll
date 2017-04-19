using System;
using NUnit.Framework;
using Payroll;

namespace PayrollTest
{
	[TestFixture]
	public class TestTimeCardTransaction
	{
		[Test]
		public void TimeCardTransactionTest()
		{
			int empId = 5;
			var t = new AddHourlyEmployee(empId,"Bill","Home",15.25);
			t.Execute();

			var tct = new TimeCardTransaction(new DateTime(2005,7,31),8.0,empId);
			tct.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);

			var pc = e.Classification;
			Assert.IsTrue(pc is HourlyClassification);
			var hc = pc as HourlyClassification;

			var tc = hc.GetTimeCard(new DateTime(2005, 7, 31));
			Assert.IsNotNull(tc);
			Assert.AreEqual(8.0,tc.Hours);

		}
	}
}
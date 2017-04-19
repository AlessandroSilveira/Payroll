using NUnit.Framework;
using Payroll;

namespace PayrollTest
{
	[TestFixture]
	public class TestChangeNameTransaction
	{
		[Test]
		public void ChangeNameTransactionTest()
		{
			int empId = 2;

			AddHourlyEmployee t = new AddHourlyEmployee(empId,"Bill","Home",15.25);
			t.Execute();

			ChangeNameTransaction cnt = new ChangeNameTransaction(empId,"Bob");
			cnt.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);
			Assert.AreEqual("Bob",e.Name);

		}
	}
}
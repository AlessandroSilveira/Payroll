using NUnit.Framework;
using Payroll;


namespace PayrollTest
{
	[TestFixture()]
	public class TestChangeAdressTransaction
	{
		[Test]
		public void ChangeAdressTransactionTest()
		{
			int empId = 2;

			AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
			t.Execute();

			ChangeAddressTransaction cnt = new ChangeAddressTransaction(empId, "Work");
			cnt.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);
			Assert.AreEqual("Work", e.Address);
		}
	}
}
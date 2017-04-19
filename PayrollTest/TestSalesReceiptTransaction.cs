using System;
using NUnit.Framework;
using Payroll;

namespace PayrollTest
{
	[TestFixture]
	public class TestSalesReceiptTransaction
	{
		public void SalesReceiptTransactionTest()
		{
			int empId = 6;
			var t = new AddCommissionedEmployee(empId,"Bob","home",1000,3.0);
			t.Execute();

			var sr = new SalesReceiptTransaction(empId );
			sr.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);

			var pc = e.Classification;
			Assert.IsTrue(pc is CommissionedClassification);
			var hc = pc as CommissionedClassification;

			var tc = hc.GetSalesReceipt(empId,new DateTime(2017, 04, 17));
			Assert.IsNotNull(tc);

		}
	}
}
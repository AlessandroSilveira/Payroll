using System;

namespace Payroll
{
	public class SalesReceiptTransaction :SalesReceipt, ITransaction
	{
		private static readonly DateTime date;
		private static readonly double amount;
		private readonly int _empId;

		public SalesReceiptTransaction(int empId):base(date,amount)
		{
			_empId = empId;
		}

		public void Execute()
		{
			var e = PayrollDatabase.GetEmployee(_empId);

			if (e == null)
			{
				throw new InvalidOperationException("No Such employee");
			}
			var sr = e.Classification as CommissionedClassification;
			if (sr != null)
				sr.AddSalesReceipt(new SalesReceipt(date, amount));
			else
				throw new InvalidOperationException("Tried to add sales receipt");
		}
	}
}
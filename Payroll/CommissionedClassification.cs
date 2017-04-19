using System;

namespace Payroll
{
	public class CommissionedClassification : PaymentClassification
	{
		private double _commissionRate;
		private double _salary;

		public CommissionedClassification(double salary, double commissionRate)
		{
			this._salary = salary;
			this._commissionRate = commissionRate;
		}

		public double Salary => _salary * _commissionRate;

		public void AddSalesReceipt(SalesReceipt salesReceipt)
		{
			var receipt = new SalesReceipt(salesReceipt.Date, salesReceipt.Amount);
		}

		//public SalesReceipt GetSalesReceipt(int id, DateTime dateTime) => PayrollDatabase.GetSalesReceipt(id,dateTime);
		public SalesReceipt GetSalesReceipt( DateTime dateTime)
		{
			return new SalesReceipt(dateTime,3.0);
		}
	}
}
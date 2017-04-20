using System;

namespace Payroll
{
	public class Employee 
	{
	    public Employee(int empId, string name, string address)
		{
			this.EmpId = empId;
			this.Name = name;
			this.Address = address;

		}

		public int EmpId { get; }

	    public string Name { get; set; }

	    public string Address { get; set; }

	    public PaymentSchedule Schedule { get; set; }
		public PaymentClassification Classification { get; set; }
		public PaymentMethod Method { get; set; }
		public Affiliation Affiliation { get; set; }
		public UnionAffiliation UnionAffiliation { get; set; }

		

		public void PayDay(PayCheck payCheck)
		{
			double grossPay = Classification.CalculatePay(payCheck);
			double deductions = Affiliation.CalculateDeductions(payCheck);
			double netPay = grossPay - deductions;
			payCheck.GrossPay = grossPay;
			payCheck.Deductions = deductions;
			payCheck.NetPay = netPay;
			Method.Pay(payCheck);
		}

		public bool IsPayDate(DateTime payDate)
		{
			throw new NotImplementedException();
		}
	}
}
namespace Payroll
{
	public class AddCommissionedEmployee : AddEmployeeTransaction
	{
		private readonly double _salary;
		private readonly double _commissionRate;

		public AddCommissionedEmployee(int empid, string name, string address, double salary, double commissionRate) : base(empid, name, address)
		{
			this._salary = salary;
			this._commissionRate = commissionRate;
		}

		protected override PaymentClassification MakeClassification()
		{
			return new CommissionedClassification(_salary, _commissionRate);
		}

		protected override PaymentSchedule MakeSchedule()
		{
			return new BiweeklyScheddule();
		}
	}
}
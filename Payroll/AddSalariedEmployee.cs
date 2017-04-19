namespace Payroll
{
	public class AddSalariedEmployee : AddEmployeeTransaction
	{
		private readonly double _salary;

		public AddSalariedEmployee(int empid, string name, string address,double salary) : base(empid, name, address)
		{
			this._salary = salary;
		}

		protected override PaymentClassification MakeClassification()
		{
			return new SalariedClassification(_salary);
		}

		protected override PaymentSchedule MakeSchedule()
		{
			return new MonthlySchedule();
		}
	}
}

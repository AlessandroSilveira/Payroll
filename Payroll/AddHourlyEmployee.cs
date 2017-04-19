namespace Payroll
{
	public class AddHourlyEmployee : AddEmployeeTransaction
	{
		private readonly double _hourlyRate;

		public AddHourlyEmployee(int empid, string name, string address, double hourlyRate) : base(empid, name, address)
		{
			this._hourlyRate = hourlyRate;
		}

		protected override PaymentClassification MakeClassification()
		{
			return new HourlyClassification();
		}

		protected override PaymentSchedule MakeSchedule()
		{
			return new BiweeklyScheddule();
		}
	}
}

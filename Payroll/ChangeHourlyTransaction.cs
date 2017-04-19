namespace Payroll
{
	public abstract class ChangeHourlyTransaction : ChangeEmployeeTransaction
	{
		public readonly double hourlyRate;

		protected ChangeHourlyTransaction(int empId, double hourlyRate ) : base(empId)
		{
			this.hourlyRate = hourlyRate;
		}


		protected override PaymentClassification Classification => new HourlyClassification(hourlyRate);
		protected PaymentSchedule Schedule => new WeeklySchedule();
	}
}
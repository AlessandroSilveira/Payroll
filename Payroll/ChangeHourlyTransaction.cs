namespace Payroll
{
	public  class ChangeHourlyTransaction : ChangeClassificationTransaction
	{
		public readonly double hourlyRate;

		public ChangeHourlyTransaction(int empId, double hourlyRate ) : base(empId)
		{
			this.hourlyRate = hourlyRate;
		}


		protected override PaymentClassification Classification => new HourlyClassification(hourlyRate);
		protected override PaymentSchedule Schedule => new PaymentSchedule();
	}
}
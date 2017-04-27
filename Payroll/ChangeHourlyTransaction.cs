namespace Payroll
{
	public  class ChangeHourlyTransaction : ChangeClassificationTransaction
	{
		public readonly double HourlyRate;

		public ChangeHourlyTransaction(int empId, double hourlyRate ) : base(empId)
		{
			this.HourlyRate = hourlyRate;
		}


		protected override PaymentClassification Classification => new HourlyClassification(HourlyRate);
		protected override PaymentSchedule Schedule => new PaymentSchedule()
			;
	}
}
namespace Payroll
{
	public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
	{
		protected ChangeClassificationTransaction(int empId) : base(empId)
		{
		}

		protected abstract PaymentClassification Classification { get; }
		protected abstract PaymentSchedule Schedule { get; }

		protected override void Change(Employee e)
		{
			e.Classification = Classification;
			e.schedule = Schedule;
		}
	}
}
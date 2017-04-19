using System;

namespace Payroll
{
	public abstract class ChangeEmployeeTransaction : ITransaction
	{
		private readonly int empId;

		protected ChangeEmployeeTransaction(int empId)
		{
			this.empId = empId;
		}

		protected abstract PaymentClassification Classification { }


		public void Execute()
		{
			Employee e = PayrollDatabase.GetEmployee(empId);

			if (e != null)
				Change(e);
			else
				throw new InvalidOperationException("No such employee.");
		}

		protected abstract void Change(Employee e);
	}
}
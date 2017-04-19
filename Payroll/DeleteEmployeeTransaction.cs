namespace Payroll
{
	public class DeleteEmployeeTransaction :DeleteEmployee, ITransaction
	{
		private readonly int _empId;

		public DeleteEmployeeTransaction(int empId) :base(empId)
		{
			_empId = empId;
		}

		public void Execute()
		{
			PayrollDatabase.DeleteEmployee(_empId);
		}
	}
}
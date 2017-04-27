namespace Payroll
{
	public class DeleteEmployeeTransaction :DeleteEmployee, ITransaction
	{
		private static readonly int id;

		public DeleteEmployeeTransaction(int empId) :base(id)
		{
		}

		public void Execute()
		{
			PayrollDatabase.DeleteEmployee(id);
		}
	}
}
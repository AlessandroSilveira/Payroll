namespace Payroll
{
	public class DeleteEmployee
	{
		private readonly int _empId;

		public DeleteEmployee(int empId)
		{
			_empId = empId;
		}

		public int EmpId => _empId;
	}
}
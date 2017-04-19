namespace Payroll
{
	public class ChangeAddressTransaction : ChangeEmployeeTransaction
	{
		private readonly string _newAddress;

		public ChangeAddressTransaction(int empId, string newAddress) : base(empId)
		{
			_newAddress = newAddress;
		}

		protected override void Change(Employee e)
		{
			e.Address = _newAddress;
		}
	}
}
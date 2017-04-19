using static Payroll.PayrollDatabase;

namespace Payroll
{
	public abstract class AddEmployeeTransaction :ITransaction
	{

		//Usando o Design pattern TEMPLATE METHOD

		private readonly int _empId;
		private readonly string _name;
		private readonly string _address;

		protected AddEmployeeTransaction(int empid,string name,string address)
		{
			this._empId = empid;
			this._name = name;
			this._address = address;
		}

		protected abstract PaymentClassification MakeClassification();
		protected abstract PaymentSchedule MakeSchedule();

		public void Execute()
		{
			var pc = MakeClassification();
			var ps = MakeSchedule();
			var pm = new HoldMethod();

			var e = new Employee(_empId, _name, _address)
			{
				Classification = pc,
				Schedule = ps,
				Method = pm
			};

			AddEmployee(_empId,e);
		}
	}
}
using System;
using System.Collections;
using Payroll;

namespace PayrollTest
{
	public class PaydayTransaction : ITransaction
	{
		private readonly DateTime _payDate;

		public PaydayTransaction(DateTime payDate)
		{
			this._payDate = payDate;
		}

		public void Execute()
		{
			ArrayList empIds = PayrollDatabase.GetAllEmployee();

			foreach (int empId in empIds)
			{
				Employee employee = PayrollDatabase.GetEmployee(empId);
				if (employee.IsPayDate(_payDate))
				{
					PayCheck pc = new PayCheck(_payDate);
					paychecks[empId] = pc;
					employee.PayDay(pc);
				}

			}
		}

		public PayCheck GetPaycheck(int empId)
		{
			throw new NotImplementedException();
		}
	}
}

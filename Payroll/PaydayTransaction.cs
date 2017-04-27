using System;
using System.Collections;

namespace Payroll
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
			ArrayList empIds = PayrollDatabase.GetAllEmployeeIds();
			PayCheck[] paychecks = new PayCheck[] {};
			foreach (int empId in empIds)
			{
				var employee = PayrollDatabase.GetEmployee(empId);
				if (!employee.IsPayDate(_payDate)) continue;
				DateTime startDate = employee.GetPayPeriodStartDate(_payDate);

				PayCheck pc = new PayCheck(startDate,_payDate);
				
				
				paychecks[empId] = pc;
				employee.PayDay(pc);
			}
		}

		public PayCheck GetPaycheck(int empId)
		{
			throw new NotImplementedException();
		}
	}
}

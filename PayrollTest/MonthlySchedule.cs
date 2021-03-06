﻿using System;
using Payroll;

namespace PayrollTest
{
	public class MonthlySchedule : PaymentSchedule
	{
		private bool IsLastDayOfMonth(DateTime date)
		{
			int m1 = date.Month;
			int m2 = date.AddDays(1).Month;
			return (m1 != m2);
		}

		public bool IsPayDate(DateTime payDate)
		{
			return IsLastDayOfMonth(payDate);
		}
	}
}

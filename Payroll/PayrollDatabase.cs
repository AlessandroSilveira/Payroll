using System;
using System.Collections;

namespace Payroll
{
	public class PayrollDatabase
	{

		//Usando o design pattern FAÇADE

		private static Hashtable _employees = new Hashtable();
		//private static Hashtable _timeCards = new Hashtable();
		//private static Hashtable _salesReceipties = new Hashtable();
		private static Hashtable _unionAffiliation = new Hashtable();
		//private static Hashtable _serviceCharge = new Hashtable();

		public static void AddEmployee(int id, Employee employee)
		{
			_employees[id] = employee;
		}

		public static Employee GetEmployee(int id)
		{
			return _employees[id] as Employee;
		}

		public static void DeleteEmployee(int empId)
		{
			_employees.Remove(empId);
		}

		//public static void AddTimeCard(int id,TimeCard timeCard)
		//{
		//	_timeCards[id] = timeCard;
		//}

		//public static void AddSalesReceipt(int id, SalesReceipt salesReceipt)
		//{
		//	_salesReceipties[id] = salesReceipt;
		//}


		//public static SalesReceipt GetSalesReceipt(int id, DateTime dateTime)
		//{
		//	return _salesReceipties[id] as SalesReceipt;
		//}

		public static void AddUnionMember(int id, Employee employee)
		{
			_unionAffiliation[id] = employee;
		}

		public static Employee GetUnionMember(int id)
		{
			return _unionAffiliation[id] as Employee;
		}

		//public static void AddServiceCharge(int id,ServiceCharge serviceCharge)
		//{
		//	_serviceCharge[id] = serviceCharge;
		//}
	}
}
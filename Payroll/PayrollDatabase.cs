using System;
using System.Collections;

namespace Payroll
{
	public class PayrollDatabase
	{

		//Usando o design pattern FAÇADE

		private static Hashtable _employees = new Hashtable();
		private static Hashtable _unionAffiliation = new Hashtable();
		


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

		
		public static void AddUnionMember(int id, Employee employee)
		{
			_unionAffiliation[id] = employee;
		}

		public static Employee GetUnionMember(int id)
		{
			return _unionAffiliation[id] as Employee;
		}

		
		public static void RemoveUnionMember(int memberId)
		{
			_unionAffiliation.Remove(memberId);
		}


		public static ArrayList GetAllEmployeeIds()
		{
			throw new NotImplementedException();
		}
	}
}
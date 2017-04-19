namespace Payroll
{
	public class SalariedClassification : PaymentClassification
	{
		private static double _salary;


		public SalariedClassification(double salary)
		{
			_salary = salary;
		}


		public double Salary => _salary;
	}
}
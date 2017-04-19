namespace Payroll
{
	public class Employee 
	{
		private int _empId;
		public string Name;
		private string _address;

		public Employee(int empId, string name, string address)
		{
			this._empId = empId;
			this.Name = name;
			this._address = address;

		}

		public PaymentSchedule Schedule { get; set; }
		public PaymentClassification Classification { get; set; }
		public PaymentMethod Method { get; set; }
		public UnionAffiliation Affiliation { get; set; }
	}
}
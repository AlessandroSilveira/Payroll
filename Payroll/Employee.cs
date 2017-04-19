namespace Payroll
{
	public class Employee 
	{
		private int _empId;
		private string _name;
		private string _address;

		public Employee(int empId, string name, string address)
		{
			this._empId = empId;
			this._name = name;
			this._address = address;

		}

		public int EmpId => _empId;
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}

		public PaymentSchedule Schedule { get; set; }
		public PaymentClassification Classification { get; set; }
		public PaymentMethod Method { get; set; }
		public UnionAffiliation Affiliation { get; set; }
		
	}
}
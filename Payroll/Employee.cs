namespace Payroll
{
	public class Employee 
	{
	    public Employee(int empId, string name, string address)
		{
			this.EmpId = empId;
			this.Name = name;
			this.Address = address;

		}

		public int EmpId { get; }

	    public string Name { get; set; }

	    public string Address { get; set; }

	    public PaymentSchedule Schedule { get; set; }
		public PaymentClassification Classification { get; set; }
		public PaymentMethod Method { get; set; }
		public Affiliation Affiliation { get; set; }
		
	}
}
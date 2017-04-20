namespace Payroll
{
    public class ChangeSalariedTransaction : ChangeClassificationTransaction
    {

        private readonly double _salary;

        public ChangeSalariedTransaction(int empId, double salary) : base(empId)
        {
            _salary = salary;
        }
        protected override PaymentClassification Classification => new SalariedClassification(_salary);
        protected override PaymentSchedule Schedule => new MonthlySchedule();

      
    }
}
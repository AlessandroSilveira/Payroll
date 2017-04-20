namespace Payroll
{
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private readonly double _salary;
        private readonly double _commissionedRate;

        public ChangeCommissionedTransaction(int empId, double salary, double commissionedRate) : base(empId)
        {
            this._salary = salary;
            this._commissionedRate = commissionedRate;
        }

        protected override PaymentClassification Classification => new CommissionedClassification(_salary, _commissionedRate);
        protected override PaymentSchedule Schedule => new MonthlySchedule();
    }
}
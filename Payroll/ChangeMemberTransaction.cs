namespace Payroll
{
    public class ChangeMemberTransaction : ITransaction
    {
        private int _empId;
        private int _memberId;
        private double v;

        public ChangeMemberTransaction(int empId, int memberId, double v)
        {
            this._empId = empId;
            this._memberId = memberId;
            this.v = v;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using Payroll;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PayrollTest
{
	[TestFixture]
	public class PayrollTest
	{
		[Test]
		public void TestAddCommissionedEmployeetest()
		{
			var empId = 1;
			var t = new AddCommissionedEmployee(empId, "Kurt", "Home", 2000, 3.2);
			t.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			Assert.AreEqual("Kurt", e.Name);

			var pc = e.Classification;
			Assert.IsTrue(pc is CommissionedClassification);
			var sc = pc as CommissionedClassification;
			Assert.AreEqual(6400, sc.Salary, .0001);
			var ps = e.schedule;
			Assert.IsTrue(ps is BiweeklyScheddule);

			var pm = e.Method;
			Assert.IsTrue(pm is HoldMethod);

		}

		[Test]
		public void TestAddHourlyEmployeetest()
		{
			var empId = 1;
			var t = new AddHourlyEmployee(empId, "Ale", "Home", 15.35);
			t.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			Assert.AreEqual("Ale", e.Name);

			var pc = e.Classification;
			Assert.IsTrue(pc is HourlyClassification);
			var sc = pc as HourlyClassification;
			Assert.AreEqual(122.8, sc.Salary, .0001);
			var ps = e.schedule;
			Assert.IsTrue(ps is BiweeklyScheddule);

			var pm = e.Method;
			Assert.IsTrue(pm is HoldMethod);

		}

		[Test]
		public void TestChangeHourlyTransaction()
		{
			int empId = 3;

			AddCommissionedEmployee t = new AddCommissionedEmployee(empId,"Lance","Home",2500,3.2);
			t.Execute();

			var cht = new ChangeHourlyTransaction(empId, 27.52);
			cht.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);
			PaymentClassification pc = e.Classification;
			Assert.IsNotNull(pc);
			Assert.IsTrue(pc is HourlyClassification);

			HourlyClassification hc = pc as HourlyClassification;
			Assert.AreEqual(220.16, hc.Salary, .001);
			var pm = e.Method;
			Assert.IsTrue(pm is HoldMethod);

		}

	    [Test]
	    public void ChangeUnionMember()
	    {
			int empId = 8;
			var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
			t.Execute();

			int memberId = 7743;
			var cmt = new ChangeMemberTransaction(empId, memberId, 99.42);
			cmt.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);

			Affiliation affiliation = e.Affiliation;
			Assert.IsNotNull(affiliation);
			Assert.IsTrue(affiliation is UnionAffiliation);

			var uf = affiliation as UnionAffiliation;
			Assert.AreEqual(99.42, uf.Dues, .001);

			var member = PayrollDatabase.GetUnionMember(memberId);

			Assert.IsNotNull(member);
		}

		[Test]
		public void AddServiceCharge()
		{
			int empId = 2;

			var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
			t.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			NUnit.Framework.Assert.IsNotNull(e);

			var af = new UnionAffiliation();
			e.Affiliation = af;
			int memberId = 86;
			PayrollDatabase.AddUnionMember(memberId, e);
			var sct = new ServiceChargeTransaction(new DateTime(2017, 04, 19), memberId, 12.95);
			sct.Execute();

			var sc = af.GetServiceCharge(new DateTime(2017, 04, 19),12.95);
			NUnit.Framework.Assert.IsNotNull(sc);
			NUnit.Framework.Assert.AreEqual(12.95, sc.Amount, .001);

		}

		[Test]
		public void DeleteEmployeeTeste()
		{
			int empId = 4;
			var t = new AddCommissionedEmployee(empId, "Bill", "Home", 2500, 3.2);
			t.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);
			var dt = new DeleteEmployeeTransaction(empId);
			dt.Execute();

			e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNull(e);

		}

		[Test]
		public void TestAddSalariedEmployeetest()
		{
			var empId = 1;
			var t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
			t.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			Assert.AreEqual("Bob", e.Name);

			var pc = e.Classification;
			Assert.IsTrue(pc is SalariedClassification);
			var sc = pc as SalariedClassification;
			Assert.AreEqual(1000.00, sc.Salary, .001);
			var ps = e.schedule;
			Assert.IsTrue(ps is MonthlySchedule);

			var pm = e.Method;
			Assert.IsTrue(pm is HoldMethod);

		}

		[Test]
		public void ChangeAdressTransactionTest()
		{
			int empId = 2;

			AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
			t.Execute();

			ChangeAddressTransaction cnt = new ChangeAddressTransaction(empId, "Work");
			cnt.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);
			Assert.AreEqual("Work", e.Address);
		}

		[Test]
		public void ChangeNameTransactionTest()
		{
			int empId = 2;

			AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
			t.Execute();

			ChangeNameTransaction cnt = new ChangeNameTransaction(empId, "Bob");
			cnt.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);
			Assert.AreEqual("Bob", e.Name);

		}
		[Test]
		public void SalesReceiptTransactionTest()
		{
			int empId = 6;
			var t = new AddCommissionedEmployee(empId, "Bob", "home", 1000, 3.0);
			t.Execute();

			var sr = new SalesReceiptTransaction(empId);
			sr.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);

			var pc = e.Classification;
			Assert.IsTrue(pc is CommissionedClassification);
			var hc = pc as CommissionedClassification;

			var tc = hc.GetSalesReceipt(new DateTime(2017, 04, 17));
			Assert.IsNotNull(tc);

		}

		[Test]
		public void TimeCardTransactionTest()
		{
			int empId = 5;
			var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
			t.Execute();

			var tct = new TimeCardTransaction(new DateTime(2005, 7, 31), 8.0, empId);
			tct.Execute();

			var e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);

			var pc = e.Classification;
			Assert.IsTrue(pc is HourlyClassification);
			var hc = pc as HourlyClassification;

			var tc = hc.GetTimeCard(new DateTime(2005, 7, 31));
			Assert.IsNotNull(tc);
			Assert.AreEqual(8.0, tc.Hours);

		}

		[Test]
		public void PaySingleSalarieEmployee()
		{
			int empId = 1;
			AddSalariedEmployee t= new AddSalariedEmployee(empId,"Bob","Home",1000.00);
			t.Execute();

			DateTime payDate = new DateTime(2001,11,30);
			PaydayTransaction pt = new PaydayTransaction(payDate);
			pt.Execute();

			PayCheck pc = pt.GetPaycheck(empId);
			Assert.IsNotNull(pc);
			Assert.AreEqual(payDate,pc.PayDate);
			Assert.AreEqual(1000.00, pc.GrossPay,.001);
			Assert.AreEqual("Hold",pc.GetField("Disposition"));
			Assert.AreEqual(0.0, pc.Deductions,.001);
			Assert.AreEqual(1000.00, pc.NetPay,.001);

		}

		[Test]
		public void PaySilgleSalariedEmployeeOnWorngDate()
		{
			int empId = 1;
			AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
			t.Execute();

			DateTime payDate = new DateTime(2001, 11, 29);
			PaydayTransaction pt = new PaydayTransaction(payDate);
			pt.Execute();

			PayCheck pc = pt.GetPaycheck(empId);
			Assert.IsNull(pc);
		}

		[Test]
		public void PayingSingleHourlyEmployeeNoTimeCards()
		{
			int empId = 2;
			AddHourlyEmployee t= new AddHourlyEmployee(empId,"Bill","Home",15.25);
			t.Execute();

			DateTime payDate = new DateTime(2001,11,9);
			PaydayTransaction pt = new PaydayTransaction(payDate);
			pt.Execute();

			ValidateHourlyPaycheck(pt, empId, payDate, 0.0);
		}

		private void ValidateHourlyPaycheck(PaydayTransaction pt, int empId, DateTime payDate, double pay)
		{
			PayCheck pc = pt.GetPaycheck(empId);
			Assert.IsNotNull(pc);
			Assert.AreEqual(payDate,pc.PayDate);
			Assert.AreEqual(pay,pc.GrossPay);
			Assert.AreEqual("Hold",pc.GetField("Disposition"));
			Assert.AreEqual(0.0,pc.Deductions,.001);
			Assert.AreEqual(pay,pc.NetPay,.001);
		}


		[Test]
		public void PaySingleHourlyEmployeeOneTimeCard()
		{
			int empId = 2;
			AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
			t.Execute();

			DateTime payDate = new DateTime(2001, 11, 9);
			TimeCardTransaction tc = new TimeCardTransaction(payDate,2.0,empId);
			tc.Execute();

			PaydayTransaction pt = new PaydayTransaction(payDate);
			pt.Execute();
			ValidateHourlyPaycheck(pt, empId, payDate, 30.5);
		}

		[Test]
		public void PaySingleHourlyEmployeeOvertimeOneTimeCard()
		{
			int empId = 2;
			AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
			t.Execute();

			DateTime payDate = new DateTime(2001, 11, 9);
			TimeCardTransaction tc = new TimeCardTransaction(payDate, 9.0, empId);
			tc.Execute();

			PaydayTransaction pt = new PaydayTransaction(payDate);
			pt.Execute();
			ValidateHourlyPaycheck(pt, empId, payDate, (8+1.5)*15.25 );
		}

		[Test]
		public void PaySingleHourlyEmployeeOnWrongDate()
		{
			int empId = 2;
			AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
			t.Execute();

			DateTime payDate = new DateTime(2001, 11, 9);
			TimeCardTransaction tc = new TimeCardTransaction(payDate, 9.0, empId);
			tc.Execute();

			PaydayTransaction pt = new PaydayTransaction(payDate);
			pt.Execute();
			PayCheck pc = pt.GetPaycheck(empId);
			Assert.IsNull(pc);
		}

		[Test]
		public void PaySingleHourlyEmployeeTwoTimeCards()
		{
			int empId = 2;
			AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
			t.Execute();

			DateTime payDate = new DateTime(2001, 11, 9);

			TimeCardTransaction tc = new TimeCardTransaction(payDate, 2.0, empId);
			tc.Execute();

			TimeCardTransaction tc2 = new TimeCardTransaction(payDate.AddDays(-1), 5.0, empId);
			tc2.Execute();

			PaydayTransaction pt = new PaydayTransaction(payDate);
			pt.Execute();
			
			ValidateHourlyPaycheck(pt,empId,payDate,7*15.25);
		}



		[Test]
		public void TestPaySingleHourlyEmployeeWithTimeCardsSpanningTwoPayPeriods()
		{
			
			int empId = 2;
			AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
			t.Execute();

			DateTime payDate = new DateTime(2001, 11, 9);
			DateTime dateInPreviousPayPariod = new DateTime(2001,11,2);

			TimeCardTransaction tc = new TimeCardTransaction(payDate, 2.0, empId);
			tc.Execute();

			TimeCardTransaction tc2 = new TimeCardTransaction(dateInPreviousPayPariod, 5.0, empId);
			tc2.Execute();

			PaydayTransaction pt = new PaydayTransaction(payDate);
			pt.Execute();

			ValidateHourlyPaycheck(pt, empId, payDate, 2 * 15.25);
		}


		[Test]
		public void SalariedUnionMemberDues()
		{
			int empId = 1;
			AddSalariedEmployee t = new AddSalariedEmployee(empId,"Bob","Home",1000.0);
			t.Execute();

			int memberId = 7734;
			ChangeMemberTransaction cmt = new ChangeMemberTransaction(empId,memberId,9.42);
			cmt.Execute();

			DateTime payDate = new DateTime(2001,11,30);
			PaydayTransaction pt = new PaydayTransaction(payDate);
			pt.Execute();

			PayCheck pc = pt.GetPaycheck(empId);
			Assert.IsNotNull(pc);
			Assert.AreEqual(payDate,pc.PayDate);
			Assert.AreEqual(1000.0,pc.GrossPay,.001);
			Assert.AreEqual("Hold",pc.GetField("Disposition"));
			Assert.AreEqual(5,pc.Deductions,.001);
			Assert.AreEqual(1000.0 - 5,pc.NetPay,.001);

		}

	}
}
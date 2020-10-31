using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll_KhodasevichVV;

namespace PayrollTest_KhodasevichVV
{
    [TestClass]
    public class Payroll_KhodasevichVV
    {
        [TestMethod]
        public void TestEmployee()
        {
            int EmpId = 1;
            Employee e = new Employee(EmpId, "Bob", "Home");
            Assert.AreEqual("Bob", e.name);
            Assert.AreEqual("Home", e.address);
            Assert.AreEqual(EmpId, e.EmpId);
        }

        [TestMethod]
        public void TestToString()
        {
            StringBuilder builder = new StringBuilder();
            Employee employee = new Employee(2, "Иван", "Готчина 27");

            builder.Append("Сотрудник #").Append(employee.EmpId).Append(" ");
            builder.Append(employee.name).Append(" ");
            builder.Append(employee.address).Append(" ");
            builder.Append("Зарплата ").Append(employee.classification).Append(" ");
            builder.Append(employee.schedule);
            builder.Append(" через ").Append(employee.method);
        }
        [TestMethod]
        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Йорик", "Гочина 23", 2000.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Йорик", e.name);
            PaymentClassification pc = e.classification;
            Assert.IsTrue(pc is SalariedClassification);
            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(2000.00, sc.Salary, .001);
            PaymentSchedule ps = e.schedule;
            Assert.IsTrue(ps is MonthlySchedule);
            PaymentMethod pm = e.method;
            Assert.IsTrue(pm is HoldMethod);
        }
        [TestMethod]
        public void TestAddHourlyEmployee()
        {
            int empId = 1;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Йорик", "Гочина 23", 2000.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Йорик", e.name);
            PaymentClassification pc = e.classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification sc = pc as HourlyClassification;
            Assert.AreEqual(2000.00, sc.HourlyRate, .001);
            PaymentSchedule ps = e.schedule;
            Assert.IsTrue(ps is WeeklySchedule);
            PaymentMethod pm = e.method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [TestMethod]
        public void TestAddCommissionedEmployee()
        {
            int empId = 1;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Йорик", "Гочина 23", 2000.00, 2000.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Йорик", e.name);
            PaymentClassification pc = e.classification;
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification sc = pc as CommissionedClassification;
            Assert.AreEqual(2000.00, sc.Salary, .001);
            Assert.AreEqual(2000.00, sc.CommissionRate, .001);
            PaymentSchedule ps = e.schedule;
            Assert.IsTrue(ps is BiweeklySchedule);
            PaymentMethod pm = e.method;
            Assert.IsTrue(pm is HoldMethod);
        }
    }
}

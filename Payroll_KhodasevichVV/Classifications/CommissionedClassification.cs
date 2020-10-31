using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhodasevichVV
{
    public class CommissionedClassification : PaymentClassification
    {
        private readonly double salary;
        private readonly double commissionRate;
        public CommissionedClassification(double salary, double commissionRate)
        {
            this.salary = salary;
            this.commissionRate = commissionRate;
        }
        public double Salary
        {
            get { return salary; }
        }
        public double CommissionRate
        {
            get { return commissionRate; }
        }
        public override string ToString()
        {
            return String.Format("${0}  ${1}", salary, commissionRate);
        }
    }
}

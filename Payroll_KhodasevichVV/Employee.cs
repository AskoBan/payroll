using System;
using System.Collections.Generic;
using System.Text;
namespace Payroll_KhodasevichVV
{
    public class Employee
    {
        public int EmpId { get; }
        public string name { get; set; }
        public string address { get; set; }
        private Affiliation affiliation { get; set; }
        public PaymentClassification classification { get; set; }
        public PaymentSchedule schedule { get; set; }
        public PaymentMethod method { get; set; }


        public Employee(int empid, string name, string address)
        {
            this.EmpId = empid;
            this.address = address;
            this.name = name;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Emp#: ").Append(EmpId).Append(" ");
            builder.Append(name).Append(" ");
            builder.Append(address).Append(" ");
            builder.Append("Paid ").Append(classification).Append(" ");
            builder.Append(schedule);
            builder.Append(" by ").Append(method);
            return builder.ToString();
        }
    }
}

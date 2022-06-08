using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entry.Web.Entities
{
    public class EmployeeSalary
    {
        public int EmployeeSalaryId { get; set; }
        public int EmployeeId { get; set; }
        public int MonthId { get; set; }
        public int Year { get; set; }
        public float Salary { get; set; }
    }
}
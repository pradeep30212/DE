using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataEntry.Web.Entities
{
    public class EmployeeSalary
    {
        [Key]
        public int EmployeeSalaryId { get; set; }
        public int EmployeeId { get; set; }
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public decimal Salary { get; set; }
    }
}
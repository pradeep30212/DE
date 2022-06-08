using Entry.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entry.Web.Models
{
    public class EmployeeSalaryViewModel
    {
        public readonly static ApplicationDbContext dbContext = new ApplicationDbContext();

        public int EmployeeSalaryId { get; set; }
        public int EmployeeId { get; set; }
        public string  EmployeeName { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; } = GetEmployees();


        public int MonthId { get; set; }
        public string MonthName { get; set; }
        public IEnumerable<SelectListItem> Months { get; set; } = GetMonths();

        public int Year { get; set; }
        public float Salary { get; set; }

        public IEnumerable<EmployeeSalaryViewModel> Salaries { get; set; }

        public EmployeeSalaryViewModel Get()
        {
            Salaries = GetSalaries();
            return this;
        }

        private IEnumerable<EmployeeSalaryViewModel> GetSalaries()
        {
            var employeeSalaris = dbContext.EmployeeSalaries.ToList();

            var viewList = new List<EmployeeSalaryViewModel>();

            foreach (var employeeSalary in employeeSalaris)
            {
                viewList.Add(new EmployeeSalaryViewModel 
                {
                    EmployeeSalaryId = employeeSalary.EmployeeSalaryId,
                    EmployeeId = employeeSalary.EmployeeId,
                    MonthId = employeeSalary.MonthId,
                    Year = employeeSalary.Year,
                    Salary = employeeSalary.Salary,
                    EmployeeName = GetEmployeeName(employeeSalary.EmployeeId),
                    MonthName = GetMonthName(employeeSalary.MonthId.ToString())
                });
            }

            return viewList;
        }

        private string GetMonthName(string monthId)
        {
            var monthName = GetMonths().FirstOrDefault(x => x.Value == monthId).Text;
            return monthName;
        }

        private string GetEmployeeName(int employeeId)
        {
            var employee = dbContext.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);

            return $"{employee.FirstName} {employee.LastName}";
        }

        internal void Save()
        {
            if (this.EmployeeSalaryId == 0)
            {
                var employeeSalary = new EmployeeSalary
                {
                    EmployeeId = this.EmployeeId,
                    MonthId = this.MonthId,
                    Year = this.Year,
                    Salary = this.Salary
                };

                dbContext.EmployeeSalaries.Add(employeeSalary);
            }
            else
            {
                var es = dbContext.EmployeeSalaries.FirstOrDefault(x => x.EmployeeSalaryId == this.EmployeeSalaryId);
                if (es != null)
                {
                    es.EmployeeId = this.EmployeeId;
                    es.MonthId = this.MonthId;
                    es.Year = this.Year;
                    es.Salary = this.Salary;
                }
            }

            dbContext.SaveChanges();
        }

        private static IEnumerable<SelectListItem> GetMonths()
        {
            var months = new List<SelectListItem>();

            DateTime month = new DateTime();

            for (int i = 1; i < 13; i++)
            {
                month = new DateTime(DateTime.Now.Year, i, 1);
                months.Add(new SelectListItem
                {
                    Text = month.ToString("MMM"),
                    Value = month.Month.ToString()
                });

            }

            return months;
        }


        private static IEnumerable<SelectListItem> GetEmployees()
        {
            var employees = new List<SelectListItem>();
            var employeeList = dbContext.Employees.ToList();

            foreach (var employee in employeeList)
            {
                employees.Add(new SelectListItem
                {
                    Text = $"{employee.FirstName} {employee.LastName}",
                    Value = employee.EmployeeId.ToString()
                });
            }

            return employees;
        }
    }

}
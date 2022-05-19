using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataEntry.Web.Models
{
    public class EmployeeViewModel
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();//property intialization
        private const int x = 100;

        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First name is mandatory.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is mandatory.")]
        public string LastName { get; set; }
       
        [DataType(DataType.PhoneNumber), Required]
        public string Phone { get; set; }
        [MaxLength(500, ErrorMessage = "Enter max 500 characters")]
        public string Address { get; set; }
        public int DepartmentId { get; set; }

        public IEnumerable<EmployeeViewModel> Employees { get; set; }


        public EmployeeViewModel():this(new ApplicationDbContext())
        {
            //x = 200;
            // constant - you can not intialize anywhere. YOu need to intialize at the time declaration.
            // readonly - at the time of declaration and another inside a constructor.
        }

        internal void Save()
        {
            if (EmployeeId == 0)
            {
                _dbContext.Employees.Add(new Entities.Employee
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Address = Address,
                    Phone = Phone,
                    DepartmentId = 1
                });
            }
            else
            {
                var employee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == EmployeeId);

                employee.FirstName = FirstName;
                employee.LastName = LastName;
                employee.Address = Address;
                employee.Phone = Phone;
                employee.DepartmentId = DepartmentId;
            }

            _dbContext.SaveChanges();
        }

        internal EmployeeViewModel GetSingle(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == id);

            EmployeeViewModel employeeViewModel = null;

            if (employee != null)
            {
                employeeViewModel = new EmployeeViewModel
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Address = employee.Address,
                    DepartmentId = employee.DepartmentId,
                    Phone = employee.Phone,
                    EmployeeId = employee.EmployeeId
                };
            }

            return employeeViewModel;
        }

        internal void DeleteEmployee(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            
            _dbContext.Employees.Remove(employee);

            _dbContext.SaveChanges();
        }

        public EmployeeViewModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EmployeeViewModel Get()
        {
            Employees = GetEmployees();
            return this;
        }

        private IEnumerable<EmployeeViewModel> GetEmployees()
        {
            var employees = new List<EmployeeViewModel>();

            var list = _dbContext.Employees.ToList();

            foreach (var employee in list)
            {
                employees.Add(new EmployeeViewModel
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Phone = employee.Phone,
                    Address = employee.Address,
                    DepartmentId = employee.DepartmentId
                });
            }

            return employees;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entry.Web.Models
{
    public class DepartmentViewModel
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();//property intialization
        private const int x = 100;

        [Key]

        [Required(ErrorMessage = "DepartmentID name is mandatory.")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "DepartmentName name is mandatory.")]
        public String DepartmentName { get; set; }

        internal object GetDepartment(int id)
        {
            Departments = GetDepartments();
            return this;
        }

        public IEnumerable<DepartmentViewModel> Departments { get; set; }

        public DepartmentViewModel() : this(new ApplicationDbContext())
        {
            //x = 200;
            // constant - you can not intialize anywhere. YOu need to intialize at the time declaration.
            // readonly - at the time of declaration and another inside a constructor.
        }

        internal void Save()
        {
            if (DepartmentId == 0)
            {
                _dbContext.Departments.Add(new Entities.Department
                {
                   DepartmentID = DepartmentId,
                   DepartmentName = DepartmentName
                });
            }
            else
            {
                var Department = _dbContext.Departments.FirstOrDefault(x => x.DepartmentID == DepartmentId);

                Department.DepartmentID = DepartmentId;
                Department.DepartmentName = DepartmentName;
                
            }

            _dbContext.SaveChanges();
        }

        internal DepartmentViewModel GetSingle(int id)
        {
            var department = _dbContext.Departments.FirstOrDefault(x => x.DepartmentID == id);

            DepartmentViewModel departmentViewModel = null;

            if (department != null)
            {
                departmentViewModel = new DepartmentViewModel
                {
                    DepartmentId = department.DepartmentID,
                    DepartmentName = department.DepartmentName,
                    
                };
            }

            return departmentViewModel;
        }

        internal void DeleteDepartment(int id)
        {
            var department = _dbContext.Departments.FirstOrDefault(x => x.DepartmentID == id);

            _dbContext.Departments.Remove(department);

            _dbContext.SaveChanges();
        }

        public DepartmentViewModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DepartmentViewModel Get()
        {
            Departments = GetDepartments();
            return this;
        }
        

      private IEnumerable<DepartmentViewModel> GetDepartments()
        {
            var Departments = new List<DepartmentViewModel>();

            var list = _dbContext.Departments.ToList();

            foreach (var department in list)
            {
                Departments.Add(new DepartmentViewModel
                {
                    DepartmentId = department.DepartmentID,
                    DepartmentName = department.DepartmentName
                });
            }

            return Departments;
        }

    }
}
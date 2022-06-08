using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entry.Web.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        
        public String DepartmentName { get; set; }
    }
}
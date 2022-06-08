using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entry.Web.Entities
{
    public class Project
    {
        [Key]
        //public int ProjectID { get; internal set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDuration { get; set; }
    }
}
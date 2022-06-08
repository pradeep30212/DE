using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entry.Web.Models
{
    public class ProjectViewModel
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();
        [Key]
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "Project name is mandatory.")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Project Duration is mandatory.")]
        public string ProjectDuration { get; set; }
        public IEnumerable<ProjectViewModel> Projects { get; set; }


        public ProjectViewModel():this(new ApplicationDbContext())
        {
            //x = 200;
            // constant - you can not intialize anywhere. YOu need to intialize at the time declaration.
            // readonly - at the time of declaration and another inside a constructor.
        }

        internal void Save()
        {
            if (ProjectId == 0)
            {
                _dbContext.Projects.Add(new Entities.Project
                {
                    //ProjectId = ProjectId,
                    ProjectName = ProjectName,
                    ProjectDuration = ProjectDuration,
                    
                });
            }
            else
            {
                var project = _dbContext.Projects.FirstOrDefault(x => x.ProjectId == ProjectId);

                project.ProjectId = ProjectId;
                project.ProjectName = ProjectName;
                project.ProjectDuration = ProjectDuration;
                
            }

            _dbContext.SaveChanges();
        }

        internal ProjectViewModel GetSingle(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.ProjectId == id);

            ProjectViewModel projectViewModel = null;

            if (project != null)
            {
                projectViewModel = new ProjectViewModel
                {
                    ProjectId = project.ProjectId,
                    ProjectName = project.ProjectName,
                    ProjectDuration = project.ProjectDuration,
                    
                };
            }

            return projectViewModel;
        }

        internal void DeleteProject(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.ProjectId == id);

            _dbContext.Projects.Remove(project);

            _dbContext.SaveChanges();
        }

        public ProjectViewModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProjectViewModel Get()
        {
            Projects = GetProjects();
            return this;
        }

        private IEnumerable<ProjectViewModel> GetProjects()
        {
            var projects = new List<ProjectViewModel>();

            var list = _dbContext.Projects.ToList();

            foreach (var project in list)
            {
                projects.Add(new ProjectViewModel
                {
                    ProjectId = project.ProjectId,
                    ProjectName = project.ProjectName,
                    ProjectDuration = project.ProjectDuration,
                    
                });
            }

            return projects;
        }
        //public IEnumerable<ProjectViewModel> Project { get; set; }
    }
}
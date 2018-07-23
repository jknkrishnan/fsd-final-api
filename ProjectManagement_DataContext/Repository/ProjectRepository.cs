using ProjectManagement_DataContext.Interface;
using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_DataContext.Repository
{
    public class ProjectRepository
    {
        private ITaskAppContext projectcontext;
        public ProjectRepository(ITaskAppContext context)
        {
            projectcontext = context;
        }

        public List<Project> GetProjects()
        {
            List<Project> ls;
            ls = projectcontext.Project.ToList();
            return ls;
        }
    }
}

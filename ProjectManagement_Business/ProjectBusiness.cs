using ProjectManagement_DataContext.Interface;
using ProjectManagement_DataContext.Repository;
using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Business
{
    public class ProjectBusiness
    {
        private ITaskAppContext projcontext;

        public ProjectBusiness(ITaskAppContext context)
        {
            projcontext = context;
        }

        public List<Project> GetProjects()
        {
            List<Project> ls;
            ls = (new ProjectRepository(projcontext).GetProjects());
            return ls;
        }
    }
}

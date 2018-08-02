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

        public List<Project> GetProjects(int id)
        {
            List<Project> ls;
            ls = (new ProjectRepository(projcontext).GetProjects(id));
            return ls;
        }

        public List<Project> Post(Project ts)
        {
            List<Project> ls;
            ls = (new ProjectRepository(projcontext).Post(ts));
            return ls;
        }

        public List<Project> Put(Project ts)
        {
            List<Project> ls;
            ls = (new ProjectRepository(projcontext).Put(ts));
            return ls;

        }

        public int Delete(int id)
        {
            int ls;
            ls = (new ProjectRepository(projcontext).Delete(id));
            return ls;
        }

    }
}

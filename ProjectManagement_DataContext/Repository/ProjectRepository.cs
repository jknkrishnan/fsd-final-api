using ProjectManagement_DataContext.Interface;
using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public List<Project> GetProjects(int id)
        {
            List<Project> ls;
            ls = projectcontext.Project 
                .Include(t => t.Task)
                //.Include(pr => pr.Parent)
                .Where(p => p.Project_Id == id).ToList();
            return ls;
        }

        public List<Project> Post(Project ts)
        {
            int key = 0;
            List<Project> ls;
            projectcontext.Project.Add(ts);
            projectcontext.SaveChanges();
            key = ts.User_Id;
            ls = projectcontext.Project.Where(p => p.Project_Id == key).ToList();
            return ls;
        }

        public List<Project> Put(Project proj)
        {
            int key = 0;
            List<Project> ls;
            projectcontext.MarkAsProjectModified(proj);
            projectcontext.SaveChanges();
            key = proj.Project_Id;
            ls = projectcontext.Project.Where(p => p.Project_Id == key).ToList();
            return ls;
        }
        public int Delete(int id)
        {
            Project ts;
            ts = projectcontext.Project.FirstOrDefault(x => x.Project_Id == id);
            projectcontext.Project.Remove(ts);
            projectcontext.SaveChanges();
            return id;
        }
    }
}

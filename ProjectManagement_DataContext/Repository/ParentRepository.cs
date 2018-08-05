using ProjectManagement_DataContext.Interface;
using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_DataContext.Repository
{
    public class ParentRepository
    {
        private ITaskAppContext parentcontext;
        public ParentRepository(ITaskAppContext context)
        {
            parentcontext = context;
        }


        public List<Parent> GetParents()
        {
            List<Parent> ls;
            ls = parentcontext.Parent.ToList();            
            return ls;
        }

        public List<Parent> GetTasks(int id)
        {
            List<Parent> ls;
            ls = parentcontext.Parent
                .Where(p => p.Parent_Id == id).ToList();
            return ls;
        }

        public List<Parent> Post(Parent ts)
        {
            int key = 0;
            List<Parent> ls;
            parentcontext.Parent.Add(ts);
            parentcontext.SaveChanges();
            key = ts.Parent_Id;
            ls = parentcontext.Parent.Where(p => p.Parent_Id == key).ToList();
            return ls;
        }

        public List<Parent> Put(Parent proj)
        {
            int key = 0;
            List<Parent> ls;
            parentcontext.MarkAsParentModified(proj);
            parentcontext.SaveChanges();
            key = proj.Project_Id;
            ls = parentcontext.Parent.Where(p => p.Parent_Id == key).ToList();
            return ls;
        }
        public int Delete(int id)
        {
            Parent ts;
            ts = parentcontext.Parent.FirstOrDefault(x => x.Parent_Id == id);
            parentcontext.Parent.Remove(ts);
            parentcontext.SaveChanges();
            return id;
        }
    }    
}

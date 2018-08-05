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
    public class ParentBusiness
    {
        private ITaskAppContext parentcontext;

        public ParentBusiness(ITaskAppContext context)
        {
            parentcontext = context;
        }

        public List<Parent> GetParents()
        {
            List<Parent> ls;
            ls = (new ParentRepository(parentcontext).GetParents());
            return ls;
        }

        public List<Parent> GetParents(int id)
        {
            List<Parent> ls;
            ls = (new ParentRepository(parentcontext).GetTasks(id));
            return ls;
        }

        public List<Parent> Post(Parent ts)
        {
            List<Parent> ls;
            ls = (new ParentRepository(parentcontext).Post(ts));
            return ls;
        }

        public List<Parent> Put(Parent ts)
        {
            List<Parent> ls;
            ls = (new ParentRepository(parentcontext).Put(ts));
            return ls;

        }

        public int Delete(int id)
        {
            int ls;
            ls = (new ParentRepository(parentcontext).Delete(id));
            return ls;
        }
    }
}

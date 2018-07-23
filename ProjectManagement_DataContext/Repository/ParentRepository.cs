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
    }    
}

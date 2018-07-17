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
        private IParentAppContext parentcontext;

        public ParentBusiness(IParentAppContext context)
        {
            parentcontext = context;
        }

        public List<Parent> GetParents()
        {
            List<Parent> ls;
            ls = (new ParentRepository(parentcontext).GetParents());
            return ls;
        }
    }
}

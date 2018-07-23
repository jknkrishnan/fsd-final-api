using ProjectManagement_DataContext.Interface;
using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_DataContext.Repository
{
    public class UserRepository
    {
        private ITaskAppContext usercontext;
        public UserRepository(ITaskAppContext context)
        {
            usercontext = context;
        }

        public List<User> GetUsers()
        {
            List<User> ls;
            ls = usercontext.User.ToList();
            return ls;
        }
    }
}

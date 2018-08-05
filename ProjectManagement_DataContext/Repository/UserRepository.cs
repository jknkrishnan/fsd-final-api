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

        public List<User> GetUsers(int id)
        {
            List<User> ls;            
            ls = usercontext.User
                //.Include(p => p.Project)
                //.Include(p => p.Task)
                .Where(p => p.User_Id == id).ToList();            
            return ls;
        }

        public List<User> Post(User ts)
        {
            int key = 0;
            List<User> ls;
            usercontext.User.Add(ts);
            usercontext.SaveChanges();
            key = ts.User_Id;
            ls = usercontext.User.Where(p => p.User_Id == key).ToList();
            return ls;
        }

        public List<User> Put(User usr)
        {
            int key = 0;
            List<User> ls;
            usercontext.MarkAsUserModified(usr);
            usercontext.SaveChanges();
            key = usr.User_Id;
            ls = usercontext.User.Where(p => p.User_Id == key).ToList();
            return ls;
        }
        public int Delete(int id)
        {
            User ts;
            ts = usercontext.User.FirstOrDefault(x => x.User_Id == id);
            usercontext.User.Remove(ts);
            usercontext.SaveChanges();
            return id;
        }
    }
}

using ProjectManagement_API.Tests.DBSet;
using ProjectManagement_DataContext.Interface;
using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Tests.Context
{
    class UserTestContext : IUserAppContext
    {
        public UserTestContext()
        {
            this.User = new UserDbSet();
        }

        public DbSet<User> User { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(User item) { }
        public void Dispose() { }
    }
}

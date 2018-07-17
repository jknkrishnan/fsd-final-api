using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProjectManagement_Entities;

namespace ProjectManagement_DataContext.Interface
{    
    public interface IUserAppContext : IDisposable
    {
        DbSet<User> User { get; }
        int SaveChanges();
        void MarkAsModified(User item);
    }
}

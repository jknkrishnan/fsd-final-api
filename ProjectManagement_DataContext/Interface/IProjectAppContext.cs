using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProjectManagement_Entities;

namespace ProjectManagement_DataContext.Interface
{   
    public interface IProjectAppContext : IDisposable
    {
        DbSet<Project> Project { get; }
        int SaveChanges();
        void MarkAsModified(Project item);
    }
}

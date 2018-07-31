using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ProjectManagement_Entities;

namespace ProjectManagement_DataContext.Interface
{
    public interface ITaskAppContext : IDisposable
    {
        DbSet<Task> Task { get; }
        DbSet<Project> Project { get; }
        DbSet<User> User { get; }
        DbSet<Parent> Parent { get; }
        int SaveChanges();
        void MarkAsTaskModified(Task item);
        void MarkAsUserModified(User item);
        void MarkAsProjectModified(Project item);
        void MarkAsParentModified(Parent item);
    }
}

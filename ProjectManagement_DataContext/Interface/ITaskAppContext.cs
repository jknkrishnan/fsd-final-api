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
        int SaveChanges();
        void MarkAsModified(Task item);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagement_DataContext.Interface;
using ProjectManagement_Entities;
using System.Data.Entity;
using ProjectManagement_API.Tests.DBSet;

namespace ProjectManagement_API.Tests.Context
{
    class TaskTestContext : ITaskAppContext
    {
        public TaskTestContext()
        {
            this.Task = new TaskDBSet();
        }

        public DbSet<Task> Task { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Task item) { }
        public void Dispose() { }
    }
}

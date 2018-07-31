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
        public DbSet<Project> Project { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Parent> Parent { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsTaskModified(Task item)
        {
           
        }

        public void MarkAsUserModified(User item)
        {
           
        }

        public void MarkAsProjectModified(Project item)
        {
           
        }

        public void MarkAsParentModified(Parent item)
        {
           
        }
        public void Dispose() { }
    }
}

using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ProjectManagement_DataContext
{
    public class TaskContext : DbContext, Interface.ITaskAppContext
    {
        public TaskContext()
            : base("name=Context")
        {

        }
        public DbSet<Task> Task { get; set; }

        public void MarkAsModified(Task item)
        {
            Entry(item).State = EntityState.Modified;
        }

    }
}

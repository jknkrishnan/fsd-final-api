using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace ProjectManagement_DataContext
{
    public class TaskContext : DbContext, Interface.ITaskAppContext
    {
        public TaskContext()
            : base("name=Context")
        {
            //this.Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Task> Task { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Parent> Parent { get; set; }

        public void MarkAsTaskModified(Task item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public void MarkAsUserModified(User item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public void MarkAsProjectModified(Project item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public void MarkAsParentModified(Parent item)
        {
            Entry(item).State = EntityState.Modified;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();            
        }

    }
}

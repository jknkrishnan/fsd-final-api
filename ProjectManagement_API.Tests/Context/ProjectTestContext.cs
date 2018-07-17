using ProjectManagement_DataContext.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProjectManagement_Entities;
using ProjectManagement_API.Tests.DBSet;

namespace ProjectManagement_API.Tests.Context
{
    class ProjectTestContext : IProjectAppContext
    {
        public ProjectTestContext()
        {
            this.Project = new ProjectDbSet();
        }

        public DbSet<Project> Project { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Project item) { }
        public void Dispose() { }
    }
}

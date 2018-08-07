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
    public class ParentTestContext : IParentAppContext
    {
        public ParentTestContext()
        {
            this.Parent = new ParentDbSet();
        }

        public DbSet<Parent> Parent { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Parent item) { }
        public void Dispose() { }
    }
}

using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_DataContext
{
    public class ParentContext : DbContext, Interface.IParentAppContext
    {
        public ParentContext()
            : base("name=Context")
        {

        }
        public DbSet<Parent> Parent { get; set; }

        public void MarkAsModified(Parent item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}

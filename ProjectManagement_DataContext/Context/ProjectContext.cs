﻿using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_DataContext
{
    public class ProjectContext : DbContext, Interface.IProjectAppContext
    {
        public ProjectContext()
            : base("name=Context")
        {

        }
        public DbSet<Project> Project { get; set; }

        public void MarkAsModified(Project item)
        {
            Entry(item).State = EntityState.Modified;
        }

    }
}

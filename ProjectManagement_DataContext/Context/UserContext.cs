﻿using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_DataContext
{    
    public class UserContext : DbContext, Interface.IUserAppContext
    {
        public UserContext()
            : base("name=Context")
        {

        }
        public DbSet<User> User { get; set; }       

        public void MarkAsModified(User item)
        {
            Entry(item).State = EntityState.Modified;
        }

    }
}

﻿using ProjectManagement_DataContext.Interface;
using ProjectManagement_DataContext.Repository;
using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Business
{
    public class UserBusiness
    {
        private ITaskAppContext usercontext;

        public UserBusiness(ITaskAppContext context)
        {
            usercontext = context;
        }

        public List<User> GetUsers()
        {
            List<User> ls;
            ls = (new UserRepository(usercontext).GetUsers());
            return ls;
        }

        public List<User> GetUsers(int id)
        {
            List<User> ls;
            ls = (new UserRepository(usercontext).GetUsers(id));
            return ls;
        }

        public List<User> Post(User ts)
        {
            List<User> ls;
            ls = (new UserRepository(usercontext).Post(ts));
            return ls;
        }

        public List<User> Put(User ts)
        {
            List<User> ls;
            ls = (new UserRepository(usercontext).Put(ts));
            return ls;

        }

        public int Delete(int id)
        {
            int ls;
            ls = (new UserRepository(usercontext).Delete(id));
            return ls;
        }

    }
}

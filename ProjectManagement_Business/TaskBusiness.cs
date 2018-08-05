using ProjectManagement_DataContext.Interface;
using ProjectManagement_DataContext.Repository;
using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement_Business
{
    public class TaskBusiness
    {
        private ITaskAppContext taskcontext;

        public TaskBusiness(ITaskAppContext context)
        {
            taskcontext = context;
        }

        public List<Task> GetTasks()
        {
            List<Task> ls;
            ls = (new TaskRepository(taskcontext).GetTasks());
            return ls;
        }

        public List<Task> GetTasks(int id)
        {
            List<Task> ls;
            ls = (new TaskRepository(taskcontext).GetTasks(id));
            return ls;
        }

        public List<Task> Post(Task ts)
        {
            List<Task> ls;
            ls = (new TaskRepository(taskcontext).Post(ts));
            return ls;
        }

        public List<Task> Put(Task ts)
        {
            List<Task> ls;
            ls = (new TaskRepository(taskcontext).Put(ts));
            return ls;

        }

        public int Delete(int id)
        {
            int ls;
            ls = (new TaskRepository(taskcontext).Delete(id));
            return ls;
        }
    }
}

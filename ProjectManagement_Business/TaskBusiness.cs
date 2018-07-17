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
    }
}

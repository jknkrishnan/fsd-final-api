using ProjectManagement_DataContext.Interface;
using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectManagement_DataContext.Repository
{
    public class TaskRepository
    {
        private ITaskAppContext taskcontext;
        public TaskRepository(ITaskAppContext context)
        {
            taskcontext = context;
        }

        public List<Task> GetTasks()
        {
            List<Task> ls;
            ls = taskcontext.Task.ToList();
            return ls;
        }
    }
}

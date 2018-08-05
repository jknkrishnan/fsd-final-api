using ProjectManagement_DataContext.Interface;
using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;


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

        public List<Task> GetTasks(int id)
        {
            List<Task> ls;
            ls = taskcontext.Task                
                .Where(p => p.Task_Id == id).ToList();
            return ls;
        }

        public List<Task> Post(Task ts)
        {
            int key = 0;
            List<Task> ls;
            taskcontext.Task.Add(ts);
            taskcontext.SaveChanges();
            key = ts.Task_Id;
            ls = taskcontext.Task.Where(p => p.Task_Id == key).ToList();
            return ls;
        }

        public List<Task> Put(Task proj)
        {
            int key = 0;
            List<Task> ls;
            taskcontext.MarkAsTaskModified(proj);
            taskcontext.SaveChanges();
            key = proj.Task_Id;
            ls = taskcontext.Task.Where(p => p.Task_Id == key).ToList();
            return ls;
        }
        public int Delete(int id)
        {
            Task ts;
            ts = taskcontext.Task.FirstOrDefault(x => x.Task_Id == id);
            taskcontext.Task.Remove(ts);
            taskcontext.SaveChanges();
            return id;
        }
    }
}

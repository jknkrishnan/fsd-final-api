using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement_API.Tests.DBSet
{
    class TaskDBSet : TestDbSet<Task>
    {
        public override Task Find(params object[] keyValues)
        {
            return this.SingleOrDefault(task => task.Task_Id == (int)keyValues.Single());
        }
    }
}

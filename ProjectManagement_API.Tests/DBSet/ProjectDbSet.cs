using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Tests.DBSet
{
    class ProjectDbSet : TestDbSet<Project>
    {
        public override Project Find(params object[] keyValues)
        {
            return this.SingleOrDefault(project => project.Project_Id == (int)keyValues.Single());
        }
    }
}
}

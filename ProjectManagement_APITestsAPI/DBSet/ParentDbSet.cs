using ProjectManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Tests.DBSet
{
    class ParentDbSet : TestDbSet<Parent>
    {
        public override Parent Find(params object[] keyValues)
        {
            return this.SingleOrDefault(parent => parent.Parent_Id == (int)keyValues.Single());
        }
    }
}

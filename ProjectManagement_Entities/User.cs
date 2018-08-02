using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement_Entities
{
    public class User
    {
        public User()
        {            
        }

        [Key]
        public int User_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Employee_Id { get; set; }

        //foreign object
        public  ICollection<Project> Project { get; set; }
        public  ICollection<Task> Task { get; set; }
    }
}


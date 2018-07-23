using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement_Entities
{
    public class Project
    {
        [Key]
        public int Project_Id { get; set; }
        public string Project_Name { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public int Priority { get; set; }

        //foreign key        
        public int User_Id { get; set; }        
        public User User { get; set; }
        //foreign objects
        public ICollection<Parent> Parents { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }
}

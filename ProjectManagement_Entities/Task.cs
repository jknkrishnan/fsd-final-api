using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement_Entities
{
    public class Task
    {
        [Key]
        public int Task_Id { get; set; }

        public int? Parent_Id { get; set; }      //PARENT ID CAN BE NULL                                                    
                                                      
        public string TaskDesc { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public char Status { get; set; }

        //foreign keys
        public int Project_Id { get; set; }        
        public Project Project { get; set; }
        //foreign keys
        public int User_Id { get; set; }        
        public User User { get; set; }
    }
}

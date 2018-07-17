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

        public int Parent_Id { get; set; }            
        public Parent Parent { get; set; }
                
        public int Project_Id { get; set; }        
        public Project Project { get; set; }

        public string TaskDesc { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public Char Status { get; set; }
    }
}

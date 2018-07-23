using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement_Entities
{
    public class Parent
    {
        [Key]
        public int Parent_Id { get; set; }
        public string Parent_Task { get; set; }

        //foreign key
        public int Project_Id { get; set; }
        public Project Project { get; set; }
        
    }
}

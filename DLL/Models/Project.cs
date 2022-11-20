using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Project

    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}

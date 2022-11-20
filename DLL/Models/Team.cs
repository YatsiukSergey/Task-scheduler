using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Team
    {
       [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public ICollection<Member> Members { get; set; }
        
    }
}

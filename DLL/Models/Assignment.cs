using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime Deadline { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
       
    }
    public enum Status
    {
        NotStarted,
        InProcess,
        Finished

    }
    public enum Priority
    {
        Low,
        High,
    }
}

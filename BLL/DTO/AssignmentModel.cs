using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{

    public class AssignmentModel
    { 
      
        public string Name { get; set; }
    
        public string Description { get; set; }
     
        public int Status { get; set; }
      
        public int Priority { get; set; }
      
        public DateTime Deadline { get; set; }
    
        public int ProjectId { get; set; }
   
        public int MemberId { get; set; }
      
    }
}

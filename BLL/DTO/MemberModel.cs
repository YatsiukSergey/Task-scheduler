using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class MemberModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsBusy { get; set; }
        public int TeamId { get; set; }
     

    }
}

using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TeamModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public ICollection<Member> members{ get; set; }
    }
}

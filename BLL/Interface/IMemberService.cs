using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberModel>> GetMembers();
        Task Create(MemberModel member);
        Task DeleteMember(int member);
        Task<IEnumerable<MemberModel>> GetNotBusyMember();
        Task ChangeIsBusy(int id, bool isBusy);


    }
}

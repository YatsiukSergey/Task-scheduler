using AutoMapper;
using BLL.DTO;
using BLL.Interface;
using DAL.DBContext;
using DAL.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class MemberService : IMemberService
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        public MemberService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;

        }
        public async Task Create(MemberModel member)
        {
            await _unitOfWork.Members.Create(_mapper.Map<MemberModel, Member>(member));
            await _unitOfWork.Save();
        }

        public async Task DeleteMember(int id)
        {
            await _unitOfWork.Members.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<MemberModel>> GetMembers()
        {
            IEnumerable<MemberModel> exempl = _mapper.Map<IEnumerable<Member>, IEnumerable<MemberModel>>
             (await _unitOfWork.Members.GetList());
            return exempl;
        }

        public async Task<IEnumerable<MemberModel>> GetNotBusyMember()
        {
            IEnumerable<MemberModel> exempl = _mapper.Map<IEnumerable<Member>, IEnumerable<MemberModel>>
            (await _unitOfWork.Members.GetList()).Where(p => p.IsBusy == false);
            return exempl;
        }
        public async Task ChangeIsBusy(int id, bool isBusy)
        {

            Member member= await _unitOfWork.Members.Get(id);
            member.IsBusy = isBusy;
            await _unitOfWork.Members.Update(member);

        }
    }
}

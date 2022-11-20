using AutoMapper;
using BLL.DTO;
using BLL.Interface;
using DAL.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class TeamService : ITeamService
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        public TeamService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        public async Task<int> GetCapacity(int Id)
        {
            Team team = await _unitOfWork.Teams.Get(Id);
            int capacity = team.Capacity;
            return capacity;
        }
    }
}

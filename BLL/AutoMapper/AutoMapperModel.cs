using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL.AutoMapper
{
   public class AutoMapperModel:Profile
    {
        public AutoMapperModel()
        {
            CreateMap<Project, ProjectModel>().ReverseMap();
            CreateMap<Member, MemberModel>().ReverseMap();
            CreateMap<Team, TeamModel>().ReverseMap();
            CreateMap<Assignment, AssignmentModel>()
            .ForMember(cm => cm.Priority, o => o.MapFrom(c => (int)c.Priority))
            .ForMember(cm => cm.Status, o =>   o.MapFrom(c => (int)c.Status))
            .ReverseMap();
        }
    }
}

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
    public class ProjectService : IProjectService
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        public ProjectService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork =unitOfWork;
        }
        public async Task Create(ProjectModel projectModel)
        {
            await _unitOfWork.Projects.Create(_mapper.Map<ProjectModel, Project>(projectModel));
            await _unitOfWork.Save();
        }

        public async  Task DeleteProject(int Id)
        {
            await _unitOfWork.Projects.Delete(Id);
            await _unitOfWork.Save();
        }

       

        public async Task<ProjectModel> GetProject(int id)
        {
            ProjectModel exempl = _mapper.Map<Project, ProjectModel>
                 (await _unitOfWork.Projects.Get(id));

            return exempl;


        }
        public async Task UpdateName(int id, string name)
        {
            Project projectModel = await _unitOfWork.Projects.Get(id);
            projectModel.Name = name;
            await _unitOfWork.Projects.Update(projectModel);
        }
    }
}

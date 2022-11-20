using AutoMapper;
using BLL.DTO;
using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DLL.Interfaces;
using DAL.Models;
using System.Linq;


namespace BLL.Service
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AssignmentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        public async Task Create(AssignmentModel assignmentModel)
        {
            await _unitOfWork.Assignments.Create(_mapper.Map<AssignmentModel, Assignment>(assignmentModel));
            await _unitOfWork.Save();
            
            
            
        }

        public async Task ChangeDeadlineAsync(int id, DateTime deadline)
        {
            Assignment assignment = await _unitOfWork.Assignments.Get(id);
            assignment.Deadline = deadline;
            await _unitOfWork.Assignments.Update(assignment);
            await _unitOfWork.Save();
        }


        public async Task ChangeDescriptionAsync(int id, string description)
        {
            Assignment assignment = await _unitOfWork.Assignments.Get(id);
            assignment.Description = description;
            await _unitOfWork.Assignments.Update(assignment);
            await _unitOfWork.Save();
        }

    

        public async Task ChangePriorityAsync(int id, int priority)
        {
            Assignment assignment = await _unitOfWork.Assignments.Get(id);
            assignment.Priority =(Priority) priority;
            await _unitOfWork.Assignments.Update(assignment);
            await _unitOfWork.Save();
        }

        public async Task ChangeStatusAsync(int id, int status)
        {
            Assignment assignment = await _unitOfWork.Assignments.Get(id);
            assignment.Status = (Status) status;
            await _unitOfWork.Assignments.Update(assignment);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<AssignmentModel>> GetAssignments()
        {

       
            IEnumerable<AssignmentModel> exempl = _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentModel>>
            (await _unitOfWork.Assignments.GetList());

             return exempl;
        }
            
        

        public async Task<IEnumerable<AssignmentModel>> GetAssignmentsSortedByStatus()
        {

            IEnumerable<AssignmentModel> exempl = _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentModel>>
            (await _unitOfWork.Assignments.GetList()).OrderBy(p => p.Priority); 
            return exempl;

        }

        public async  Task<IEnumerable<AssignmentModel>> GetAssignmentByMember(int memberId)
        {
            IEnumerable<AssignmentModel> exempl = _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentModel>>
            (await _unitOfWork.Assignments.GetList()).Where(p => p.MemberId == memberId);
            return exempl;

        }
        public async Task<IEnumerable<AssignmentModel>> GetAssignmentInProject(int IdProject)
        {
            IEnumerable<AssignmentModel> exempl = _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentModel>>
            (await _unitOfWork.Assignments.GetList()).Where(p => p.ProjectId == IdProject);
            return exempl;

        }

        public async Task RemoveAssignment(int id)
        {
            await _unitOfWork.Assignments.Delete(id);
            await _unitOfWork.Save();

        }
    }
}

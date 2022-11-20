using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IAssignmentService
    {
        Task<IEnumerable<AssignmentModel>> GetAssignments();
        Task<IEnumerable<AssignmentModel>> GetAssignmentsSortedByStatus();
        Task Create(AssignmentModel assignmentModel);
        Task<IEnumerable<AssignmentModel>> GetAssignmentByMember(int idMember);
        Task ChangeDescriptionAsync(int id, string description);
        Task ChangeDeadlineAsync(int id, DateTime deadline);
        Task ChangePriorityAsync(int id, int priority);
        Task ChangeStatusAsync(int id, int status);
        Task<IEnumerable<AssignmentModel>> GetAssignmentInProject(int IdProject);
        Task RemoveAssignment(int id);
    }
}

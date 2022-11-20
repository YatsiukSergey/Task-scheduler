using BLL.DTO;
using BLL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
     
        [HttpPost]
        public async Task<ActionResult> Create(AssignmentModel assignmentModel)
        {
            await _assignmentService.Create(assignmentModel);
            
            return Ok();
        }
       [HttpPost("Deadline/{id}/{deadline}")]
        public async Task<ActionResult> ChangeDeadlineAsync(int id, DateTime deadline)
        {
            await _assignmentService.ChangeDeadlineAsync(id, deadline);
            return Ok();


        }
        [HttpPost("Description/{idAssignment}/{description}")]
        public async Task<ActionResult> ChangeDescriptionAsync(int idAssignment, string description)
        {
            await _assignmentService.ChangeDescriptionAsync(idAssignment, description);
            return Ok();

        }
        [HttpPost("Priority/{id}/{priority}")]
         public async Task<ActionResult> ChangePriorityAsync(int id, int priority)
        {
            await _assignmentService.ChangePriorityAsync(id, priority);
            return Ok();
        }
        [HttpPost("Status/{id}/{status}")]
        public async Task<ActionResult> ChangeStatusAsync(int id, int status)
        {
            await _assignmentService.ChangeStatusAsync(id, status);
            return Ok();
        }
        [HttpGet("AllAssignments")]
        public async Task<ActionResult<IEnumerable<AssignmentModel>>> GetAssignments()
        {
            IEnumerable<AssignmentModel> exempl = await _assignmentService.GetAssignments();

            return Ok(exempl);
        }
        [HttpGet("Sorted")]
        public async Task<ActionResult<IEnumerable<AssignmentModel>>> GetAssignmentsSortedByStatus()
        {

            IEnumerable<AssignmentModel> assignmentModels = await _assignmentService.GetAssignmentsSortedByStatus();
            return Ok(assignmentModels);

        }



        [HttpGet("{ProjectId}")]
        public async Task<ActionResult<IEnumerable<AssignmentModel>>> GetAssigmentsInProject(int ProjectId)
        {
            IEnumerable<AssignmentModel> assignmentModels = await _assignmentService.GetAssignmentInProject(ProjectId);
            return Ok(assignmentModels);

        }
        [HttpDelete("{AssignmentId}")]
        public async Task<ActionResult> RemoveAssignment(int AssignmentId)
        {
            await _assignmentService.RemoveAssignment(AssignmentId);
            return Ok();
          

        }



    }
}

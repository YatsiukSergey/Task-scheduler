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
    public class ProjectController : ControllerBase
    {
        private IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpPost]
        public async Task<ActionResult> Create(ProjectModel projectModel)
        {
            await _projectService.Create(projectModel);
            return Ok();
        }
        [HttpDelete("{IdProject}")]
        public async Task<ActionResult> DeleteProject(int IdProject)
        {
            await _projectService.DeleteProject(IdProject);
            return Ok();
        }
        [HttpGet("{IdProject}")]
        public async Task<ActionResult<ProjectModel>> GetProject(int IdProject)
        {
            ProjectModel projectModel = await _projectService.GetProject(IdProject);

            return Ok(projectModel);


        }
        [HttpPost("{idProject}/{name}")]
        public async Task<ActionResult> UpdateName(int idProject, string name)
        {
            await _projectService.UpdateName(idProject, name);
            return Ok();
          
        }
    }
}

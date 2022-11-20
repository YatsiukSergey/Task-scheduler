using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IProjectService
    {
        Task Create(ProjectModel projectModel);
        Task UpdateName(int id, string name);
        Task<ProjectModel> GetProject(int id);
        Task DeleteProject(int Id);

    }
}

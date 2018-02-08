using Economic.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Economic.Services
{
    public interface IProjectService
    {
        Task AddProjectAsync(Project project);

        Task UpdateProjectAsync(Project project);

        Task<Project> GetProjectByIdAsync(long projectId);

        Task<IEnumerable<Project>> GetAllProjectsByUserIdAsync(string userId);
    }
}

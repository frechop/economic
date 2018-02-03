using Economic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Services
{
    public interface IProjectService
    {
        Task AddProjectAsync(Project project);

        Task<IEnumerable<Project>> GetAllProjectsByUserIdAsync(string userId);
    }
}

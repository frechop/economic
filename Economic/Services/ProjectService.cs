using Economic.Data.Entities;
using Economic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository repository;

        public ProjectService(IProjectRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Project>> GetAllProjectsByUserIdAsync(string userId)
        {
            return await repository.GetProjectsByUserIdAsync(userId);
        }

        public async Task AddProjectAsync(Project project)
        {
            await repository.AddAsync(project);
        }
    }
}

using Economic.Data.Entities;
using Economic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Economic.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Project>> GetAllProjectsByUserIdAsync(string userId)
        {
            return await _repository.GetProjectsByUserIdAsync(userId);
        }

        public async Task AddProjectAsync(Project project)
        {
            await _repository.AddAsync(project);
        }
    }
}

using Economic.Data;
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
        private readonly EconomicContext _context;

        public ProjectService(IProjectRepository repository, EconomicContext context)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Project>> GetAllProjectsByUserIdAsync(string userId)
        {
            return await _repository.GetProjectsByUserIdAsync(userId);
        }

        public async Task AddProjectAsync(Project project)
        {
            await _repository.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
             _repository.Update(project);
        }

        public async Task<Project> GetProjectByIdAsync(long projectId)
        {
           return await _repository.GetAsync(projectId);
        }
    }
}

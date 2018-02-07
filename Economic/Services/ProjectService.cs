using Economic.Data;
using Economic.Data.Entities;
using Economic.Data.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Economic.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IdentityDbContext<User> _context;

        public ProjectService(IProjectRepository repository, IdentityDbContext<User> context)
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

        public async Task<Project> GetProjectByIdAsync(long projectId)
        {
           return await _repository.GetAsync(projectId);
        }
    }
}

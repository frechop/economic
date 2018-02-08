using Economic.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Economic.Data.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<IEnumerable<Project>> GetProjectsByUserIdAsync(string userId);
    }
}

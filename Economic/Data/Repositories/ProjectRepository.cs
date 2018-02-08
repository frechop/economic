using Economic.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Economic.Data.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
     
        public EconomicContext _ctx { get; set; }

        public ProjectRepository(EconomicContext economicContext) : base(economicContext)
        {
            _ctx = economicContext;
        }
        
        public async Task<IEnumerable<Project>> GetProjectsByUserIdAsync(string userId)
        {
            return _ctx.Projects.Where(p => p.UserGUID == userId).ToList();
        }
    }
}

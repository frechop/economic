using Economic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Data.Repositories
{
    public class ProjectRepository : Repository<ProjectEntity>, IProjectRepository
    {
     
        public EconomicContext _ctx { get; set; }

        public ProjectRepository(EconomicContext economicContext) : base(economicContext)
        {
        }
        
        public IEnumerable<ProjectEntity> GetProjectsByUserId(long userId)
        {
            return _ctx.Projects.Where(p => p.UserId == userId).ToList();
        }
    }
}

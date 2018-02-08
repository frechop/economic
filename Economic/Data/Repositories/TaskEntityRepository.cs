using Economic.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Economic.Data.Repositories
{
    public class TaskEntityRepository : Repository<TaskEntity>, ITaskEntityRepository
    {
        public EconomicContext _ctx { get; set; }

        public TaskEntityRepository(EconomicContext context) : base(context)
        {
            _ctx = context;
        }

        public async Task<IEnumerable<TaskEntity>> GetTasksByProjectIdAsync(long projectId)
        {
            return _ctx.Tasks.Where(t => t.ProjectId == projectId);
        }
    }
}

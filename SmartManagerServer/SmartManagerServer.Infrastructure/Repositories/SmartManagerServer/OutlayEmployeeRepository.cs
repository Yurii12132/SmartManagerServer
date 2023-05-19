using Microsoft.EntityFrameworkCore;
using SmartManagerServer.Core.Entities.SmartManagerServer;
using SmartManagerServer.Core.Repositories.SmartManagerServer;
using SmartManagerServer.Infrastructure.Data;
using SmartManagerServer.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Infrastructure.Repositories.SmartManagerServer
{
    public class OutlayEmployeeRepository : GenericRepository<OutlayEmployee>, IOutlayEmployeeRepository
    {
        public OutlayEmployeeRepository(SmartManagerServerContext context) : base(context) { }
        public async Task<IEnumerable<OutlayEmployee>> GetAllByObjectId(int objectId)
        {
            return await context.OutlayEmployee
                .Where(e => e.ObjectId == objectId && e.StatusId == 1)
                .Include(e => e.Employee)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OutlayEmployee> GetAsync(int id)
        {
            return await context.OutlayEmployee
                .Include(e => e.Employee)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.StatusId == 1 && x.Id == id);
        }

        public async Task<IEnumerable<OutlayEmployee>> GetByEmployeeId(int employeeId, int objectId)
        {
            return await context.OutlayEmployee
                .Where(e => e.EmployeeId == employeeId && e.ObjectId == objectId && e.StatusId == 1)
                .Include(e => e.Employee)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

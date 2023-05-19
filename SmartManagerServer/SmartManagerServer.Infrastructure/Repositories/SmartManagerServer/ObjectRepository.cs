using Microsoft.EntityFrameworkCore;
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
    public class ObjectRepository : GenericRepository<Core.Entities.SmartManagerServer.Object>, IObjectRepository
    {
        public ObjectRepository(SmartManagerServerContext context) : base(context) { }

        public async Task<IEnumerable<Core.Entities.SmartManagerServer.Object>> GetAllActive()
        {
            return await context.Object
                .Where(o => o.StatusId == 1)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Core.Entities.SmartManagerServer.Object>> GetAllClosed()
        {
            return await context.Object
                .Where(o => o.StatusId == 2)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Core.Entities.SmartManagerServer.Object> GetInformation(int id)
        {
            return await context.Object
                .Where(o => o.Id == id)
                .Include(o => o.DocumentObject)
                    .ThenInclude(f => f.File)
                .Include(o => o.ImageObject)
                    .ThenInclude(f => f.File)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Core.Entities.SmartManagerServer.Object> GetStatisticAsync(int id)
        {
            return await context.Object
                .AsNoTracking()
                .Include(x => x.Payout)
                .Include(x => x.OutlayMaterial)
                .Include(x => x.OutlayEmployee)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

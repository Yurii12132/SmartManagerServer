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
    public class OutlayMaterialRepository : GenericRepository<OutlayMaterial>, IOutlayMaterialRepository
    {
        public OutlayMaterialRepository(SmartManagerServerContext context) : base(context) { }
        public async Task<IEnumerable<OutlayMaterial>> GetAllByObjectId(int objectId)
        {
            return await context.OutlayMaterial
                .Where(o => o.ObjectId == objectId && o.StatusId == 1)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OutlayMaterial> GetAsync(int id)
        {
            return await context.OutlayMaterial
                .AsNoTracking()
                .Include(x => x.Object)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

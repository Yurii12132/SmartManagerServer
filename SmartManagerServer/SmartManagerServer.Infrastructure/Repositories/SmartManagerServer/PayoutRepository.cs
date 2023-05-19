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
    public class PayoutRepository : GenericRepository<Payout>, IPayoutRepository
    {
        public PayoutRepository(SmartManagerServerContext context) : base(context) { }
        public async Task<IEnumerable<Payout>> GetAllByObjectId(int objectId)
        {
            return await context.Payout
                .Where(p => p.ObjectId == objectId)
                .Include(x => x.Object)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Payout> GetAsync(int id)
        {
            return await context.Payout
                .Include(x => x.Object)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

using SmartManagerServer.Core.Entities.SmartManagerServer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Core.Repositories.SmartManagerServer
{
    public interface IPayoutRepository : IGenericRepository<Payout>
    {
        Task<IEnumerable<Payout>> GetAllByObjectId(int objectId);
        Task<Payout> GetAsync(int id);
    }
}

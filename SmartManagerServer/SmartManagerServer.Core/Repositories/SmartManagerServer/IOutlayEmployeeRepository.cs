using SmartManagerServer.Core.Entities.SmartManagerServer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Core.Repositories.SmartManagerServer
{
    public interface IOutlayEmployeeRepository : IGenericRepository<OutlayEmployee>
    {
        Task<IEnumerable<OutlayEmployee>> GetAllByObjectId(int objectId);
        Task<IEnumerable<OutlayEmployee>> GetByEmployeeId(int employeeId, int objectId);
        Task<OutlayEmployee> GetAsync(int id);
    }
}

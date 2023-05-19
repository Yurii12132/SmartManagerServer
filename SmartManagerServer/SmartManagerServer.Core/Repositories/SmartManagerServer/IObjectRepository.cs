using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Core.Repositories.SmartManagerServer
{
    public interface IObjectRepository : IGenericRepository<Core.Entities.SmartManagerServer.Object>
    {
        Task<Core.Entities.SmartManagerServer.Object> GetInformation(int id);
        Task<IEnumerable<Core.Entities.SmartManagerServer.Object>> GetAllActive();
        Task<IEnumerable<Core.Entities.SmartManagerServer.Object>> GetAllClosed();
        Task<Core.Entities.SmartManagerServer.Object> GetStatisticAsync(int id);
    }
}

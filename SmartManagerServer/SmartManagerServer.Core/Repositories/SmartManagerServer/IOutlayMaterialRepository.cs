using SmartManagerServer.Core.Entities.SmartManagerServer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Core.Repositories.SmartManagerServer
{
    public interface IOutlayMaterialRepository : IGenericRepository<OutlayMaterial>
    {
        Task<IEnumerable<OutlayMaterial>> GetAllByObjectId(int objectId);
        Task<OutlayMaterial> GetAsync(int id);
    }
}

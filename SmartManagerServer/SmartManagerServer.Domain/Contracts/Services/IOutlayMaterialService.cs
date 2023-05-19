using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Domain.Contracts.Services
{
    public interface IOutlayMaterialService
    {
        Task<List<OutlayMaterialModel>> GetAllByObjectIdAsync(int objectId);
        Task<int> CreateAsync(OutlayMaterialModel model);
        Task DeleteAsync(int id);
        Task<OutlayMaterialModel> GetAsync(int id);
    }
}

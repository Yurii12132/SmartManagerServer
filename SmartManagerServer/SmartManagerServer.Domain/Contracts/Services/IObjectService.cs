using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Domain.Contracts.Services
{
    public interface IObjectService
    {
        Task<List<ObjectModel>> GetAllActiveAsync();
        Task<List<ObjectModel>> GetAllClosedAsync();
        Task<int> CreateAsync(ObjectModel model);
        Task<ObjectInformationModel> GetInformationAsync(int id);
        Task DeleteAsync(int id);
        Task ClosedAsync(int id);
        Task<ObjectModel> GetAsync(int id);
        Task UpdateAsync(ObjectModel model);
        Task UpdateInformationAsync(ObjectInformationModel model);
        Task<List<StatisticObjectModel>> GetStatisticAsync(int id);
    }
}

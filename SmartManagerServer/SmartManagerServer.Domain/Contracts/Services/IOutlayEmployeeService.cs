using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Domain.Contracts.Services
{
    public interface IOutlayEmployeeService
    {
        Task<List<OutlayEmployeeOutputModel>> GetAllByObjectIdAsync(int objectId);
        Task<int> CreateAsync(OutlayEMployeeCreateFormModel model);
        Task DeleteAsync(int id);
        Task<OutlayEmployeeOutputModel> GetAsync(int id);
        Task<OutlayEmployeeOutputModel> GetByEmployeeId(int employeeId, int objectId);
    }
}

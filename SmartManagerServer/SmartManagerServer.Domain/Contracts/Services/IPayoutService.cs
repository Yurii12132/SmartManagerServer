using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Domain.Contracts.Services
{
    public interface IPayoutService
    {
        Task<List<PayoutModel>> GetAllByObjectIdAsync(int objectId);
        Task<int> CreateAsync(PayoutModel model);
        Task DeleteAsync(int id);
        Task<PayoutModel> GetAsync(int id);
    }
}

using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Domain.Contracts.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeModel> GetAsync(int id);
        Task<List<EmployeeModel>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<int> CreateAsync(EmployeeModel employeeModel);
        Task UpdateAsync(EmployeeModel employeeModel);
    }
}

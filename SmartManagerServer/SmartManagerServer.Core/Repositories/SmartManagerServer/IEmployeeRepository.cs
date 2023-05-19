using SmartManagerServer.Core.Entities.SmartManagerServer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Core.Repositories.SmartManagerServer
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetAsync(int id);
    }
}

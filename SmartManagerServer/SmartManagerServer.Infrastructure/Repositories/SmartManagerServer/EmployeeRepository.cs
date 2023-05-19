using Microsoft.EntityFrameworkCore;
using SmartManagerServer.Core.Entities.SmartManagerServer;
using SmartManagerServer.Core.Repositories.SmartManagerServer;
using SmartManagerServer.Infrastructure.Data;
using SmartManagerServer.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Infrastructure.Repositories.SmartManagerServer
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SmartManagerServerContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await context.Employee
                .Where(e => e.StatusId == 1)
                .Include(x => x.Image)
                .Include(x => x.Education)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            return await context.Employee
                .AsNoTracking()
                .Include(x => x.Image)
                .Include(x => x.Education)
                .FirstOrDefaultAsync(x => x.Id == id && x.StatusId == 1);
        }
    }
}

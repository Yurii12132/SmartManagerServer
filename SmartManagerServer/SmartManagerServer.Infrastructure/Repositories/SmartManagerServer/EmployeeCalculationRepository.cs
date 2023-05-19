using SmartManagerServer.Core.Entities.SmartManagerServer;
using SmartManagerServer.Core.Repositories.SmartManagerServer;
using SmartManagerServer.Infrastructure.Data;
using SmartManagerServer.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Infrastructure.Repositories.SmartManagerServer
{
    public class EmployeeCalculationRepository : GenericRepository<EmployeeCalculation>, IEmployeeCalculationRepository
    {
        public EmployeeCalculationRepository(SmartManagerServerContext context) : base(context)
        {
        }


    }
}

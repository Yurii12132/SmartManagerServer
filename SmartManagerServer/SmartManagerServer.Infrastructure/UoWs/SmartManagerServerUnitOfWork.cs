using SmartManagerServer.Core.Entities.SmartManagerServer;
using SmartManagerServer.Core.Repositories;
using SmartManagerServer.Core.Repositories.SmartManagerServer;
using SmartManagerServer.Core.UoWs;
using SmartManagerServer.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Infrastructure.UoWs
{
    public class SmartManagerServerUnitOfWork : ISmartManagerServerUnitOfWork
    {
        public IObjectRepository ObjectRepository { get; private set; }
        public IPayoutRepository PayoutRepository { get; private set; }
        public IOutlayMaterialRepository OutlayMaterialRepository { get; private set; }
        public IOutlayEmployeeRepository OutlayEmployeeRepository { get; private set; }
        public IEmployeeRepository EmployeeRepository { get; private set; }
        public IGenericRepository<File> IGenericFileRepository { get; private set; }
        public IGenericRepository<Education> IGenericEducationRepository { get; private set; }
        public IGenericRepository<ImageObject> IGenericImageObjectRepository { get; private set; }
        public IGenericRepository<DocumentObject> IGenericDocumentObjectRepository { get; private set; }

        private readonly SmartManagerServerContext context;

        public SmartManagerServerUnitOfWork(
            IObjectRepository ObjectRepository,
            IPayoutRepository PayoutRepository,
            IEmployeeRepository EmployeeRepository,
            IOutlayEmployeeRepository OutlayEmployeeRepository,
            IOutlayMaterialRepository outlayMaterialRepository,
            SmartManagerServerContext context
,
            IGenericRepository<File> iGenericFileService,
            IGenericRepository<Education> iGenericEducationRepository,
            IGenericRepository<ImageObject> iGenericImageObjectRepository,
            IGenericRepository<DocumentObject> iGenericDocumentObjectRepository)
        {
            this.OutlayEmployeeRepository = OutlayEmployeeRepository;
            this.EmployeeRepository = EmployeeRepository;
            this.OutlayMaterialRepository = outlayMaterialRepository;
            this.ObjectRepository = ObjectRepository;
            this.PayoutRepository = PayoutRepository;
            this.context = context;
            IGenericFileRepository = iGenericFileService;
            IGenericEducationRepository = iGenericEducationRepository;
            IGenericImageObjectRepository = iGenericImageObjectRepository;
            IGenericDocumentObjectRepository = iGenericDocumentObjectRepository;
        }
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}

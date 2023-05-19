using SmartManagerServer.Core.Entities.SmartManagerServer;
using SmartManagerServer.Core.Repositories;
using SmartManagerServer.Core.Repositories.SmartManagerServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Core.UoWs
{
    public interface ISmartManagerServerUnitOfWork : IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IOutlayMaterialRepository OutlayMaterialRepository { get; }
        IOutlayEmployeeRepository OutlayEmployeeRepository { get; }
        IPayoutRepository PayoutRepository { get; }
        IObjectRepository ObjectRepository { get; }
        IGenericRepository<File> IGenericFileRepository { get; }
        IGenericRepository<Education> IGenericEducationRepository { get; }
        IGenericRepository<ImageObject> IGenericImageObjectRepository { get; }
        IGenericRepository<DocumentObject> IGenericDocumentObjectRepository { get; }
    }
}

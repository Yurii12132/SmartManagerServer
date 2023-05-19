using AutoMapper;
using SmartManagerServer.Core.Entities.SmartManagerServer;
using SmartManagerServer.Core.Services;
using SmartManagerServer.Core.UoWs;
using SmartManagerServer.Domain.Contracts.Services;
using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Domain.Services
{
    public class ObjectService : IObjectService
    {
        private readonly ISmartManagerServerUnitOfWork smartManagerServerUnitOfWork;
        private IMapper mapper;
        private readonly IFIleService fIleService;
        public ObjectService(ISmartManagerServerUnitOfWork smartManagerServerUnitOfWork, IMapper mapper, IFIleService fIleService)
        {
            this.smartManagerServerUnitOfWork = smartManagerServerUnitOfWork;
            this.mapper = mapper;
            this.fIleService = fIleService;
        }

        public async Task ClosedAsync(int id)
        {
            var entity = await smartManagerServerUnitOfWork.ObjectRepository.GetBaseAsync(id);
            if (entity == null) throw new Exception("Object not found! Id = " + id);
            entity.StatusId = 2;
            entity.CloseDate = DateTime.Now;

            smartManagerServerUnitOfWork.ObjectRepository.Update(entity);
            await smartManagerServerUnitOfWork.SaveAsync();
        }

        public async Task<int> CreateAsync(ObjectModel model)
        {
            var entity = mapper.Map<Core.Entities.SmartManagerServer.Object>(model);
            entity.StatusId = 1;
            entity.CreateDate = DateTime.Now;

            smartManagerServerUnitOfWork.ObjectRepository.Add(entity);
            await smartManagerServerUnitOfWork.SaveAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await smartManagerServerUnitOfWork.ObjectRepository.GetBaseAsync(id);
            if (entity == null) throw new Exception("Object not found! Id = " + id);

            entity.StatusId = 3;

            smartManagerServerUnitOfWork.ObjectRepository.Update(entity);
            await smartManagerServerUnitOfWork.SaveAsync();
        }

        public async Task<List<ObjectModel>> GetAllActiveAsync()
        {
            var entities = await smartManagerServerUnitOfWork.ObjectRepository.GetAllActive();
            if (entities == null) return null;

            return mapper.Map<List<ObjectModel>>(entities);
        }

        public async Task<List<ObjectModel>> GetAllClosedAsync()
        {
            var entities = await smartManagerServerUnitOfWork.ObjectRepository.GetAllClosed();
            if (entities == null) return null;

            return mapper.Map<List<ObjectModel>>(entities);
        }

        public async Task<ObjectModel> GetAsync(int id)
        {
            var entity = await smartManagerServerUnitOfWork.ObjectRepository.GetBaseAsync(id);
            if (entity == null)
                throw new Exception("Entity not found! Id: " + id);
            var model = mapper.Map<ObjectModel>(entity);

            return model;
        }

        public async Task<ObjectInformationModel> GetInformationAsync(int id)
        {
            var information = await smartManagerServerUnitOfWork.ObjectRepository.GetInformation(id);
            if (information == null) throw new Exception("Information not found!");

            var model = mapper.Map<ObjectInformationModel>(information);

            foreach (var image in model.Images)
            {
                image.Body = await fIleService.GetImageBase64ByGuidNameAsync(image.Name);
            }



            return model;
        }

        public async Task UpdateAsync(ObjectModel model)
        {
            var entity = await smartManagerServerUnitOfWork.ObjectRepository.GetBaseAsync(model.id);
            if (entity == null)
                throw new Exception("Entity not found! Id: " + model.id);

            mapper.Map(model, entity);

            smartManagerServerUnitOfWork.ObjectRepository.Update(entity);

            await smartManagerServerUnitOfWork.SaveAsync();
        }

        public async Task UpdateInformationAsync(ObjectInformationModel model)
        {
            var entity = await smartManagerServerUnitOfWork.ObjectRepository.GetInformation(model.id);
            if (entity == null)
                throw new Exception("Entity not found!");

            mapper.Map(model, entity);

            smartManagerServerUnitOfWork.ObjectRepository.Update(entity);
            await smartManagerServerUnitOfWork.SaveAsync();

            var deletedImages = entity.ImageObject.Where(x => model.Images.All(m => x.FileId != m.id && m.id != 0));
            if (deletedImages.Any())
            {
                smartManagerServerUnitOfWork.IGenericImageObjectRepository.RemoveRange(deletedImages);
            }

            var deletedDocuments = entity.DocumentObject.Where(x => model.Documents.All(m => x.FileId != m.id && m.id != 0));
            if (deletedDocuments.Any())
            {
                smartManagerServerUnitOfWork.IGenericDocumentObjectRepository.RemoveRange(deletedDocuments);
            }

            var newImages = model.Images.Where(x => x.id == 0);
            if (newImages.Any())
            {
                foreach (var image in newImages)
                {
                    var file = new File()
                    {
                        OriginalName = image.OriginalName,
                        GuidName = await fIleService.CreateFileAsync(image.Body, image.OriginalName)
                    };
                    smartManagerServerUnitOfWork.IGenericFileRepository.Add(file);

                    await smartManagerServerUnitOfWork.SaveAsync();

                    smartManagerServerUnitOfWork.IGenericImageObjectRepository.Add(new ImageObject()
                    {
                        ObjectId = model.id,
                        FileId = file.Id
                    });
                }
            }
            await smartManagerServerUnitOfWork.SaveAsync();

            var newDocuments = model.Documents.Where(x => x.id == 0);
            if (newDocuments.Any())
            {
                foreach (var document in newDocuments)
                {
                    var file = new File()
                    {
                        OriginalName = document.OriginalName,
                        GuidName = await fIleService.CreateFileAsync(document.Body, document.OriginalName)
                    };
                    smartManagerServerUnitOfWork.IGenericFileRepository.Add(file);

                    await smartManagerServerUnitOfWork.SaveAsync();

                    smartManagerServerUnitOfWork.IGenericDocumentObjectRepository.Add(new DocumentObject()
                    {
                        ObjectId = model.id,
                        FileId = file.Id
                    });
                }
            }

            await smartManagerServerUnitOfWork.SaveAsync();
        }

        public async Task<List<StatisticObjectModel>> GetStatisticAsync(int id)
        {
            var obj = await smartManagerServerUnitOfWork.ObjectRepository.GetStatisticAsync(id);
            var startDatePayout = obj.Payout.Any() ? obj.Payout.Select(x => x.Date).Distinct().Min() : DateTime.Now;
            var startDateOutlay = obj.OutlayMaterial.Any() ? obj.OutlayMaterial.Select(x => x.Date).Distinct().Min() : DateTime.Now;
            var startDateOutlayEmployee = obj.OutlayEmployee.Any() ? obj.OutlayEmployee.Select(x => x.Date).Distinct().Min() : DateTime.Now;

            var startDate =  (new DateTime[] { startDatePayout, startDateOutlay, startDateOutlayEmployee }).Min().Date;
            var endDate = DateTime.Now.AddDays(1).Date;

            var result = new List<StatisticObjectModel>();
            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {
                var statistic = new StatisticObjectModel()
                {
                    ObjectName = obj.Name,
                    Payout = obj.Payout.Where(x => x.Date.Date == i.Date).Sum(x => x.Price),
                    Outlay = obj.OutlayMaterial.Where(x => x.Date.Date == i.Date).Sum(x => x.Price),
                    OutlayEmployee = obj.OutlayEmployee.Where(x => x.Date.Date == i.Date).Sum(x => x.Price),
                    Date = i
                };
                result.Add(statistic);
            }

            return result;
        }
    }
}

using AutoMapper;
using SmartManagerServer.Core.Entities.SmartManagerServer;
using SmartManagerServer.Core.UoWs;
using SmartManagerServer.Domain.Contracts.Services;
using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Domain.Services
{
    public class OutlayMaterialService : IOutlayMaterialService
    {
        private readonly ISmartManagerServerUnitOfWork smartManagerServerUnitOfWork;
        private IMapper mapper;
        public OutlayMaterialService(ISmartManagerServerUnitOfWork smartManagerServerUnitOfWork, IMapper mapper)
        {
            this.smartManagerServerUnitOfWork = smartManagerServerUnitOfWork;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(OutlayMaterialModel model)
        {
            var entity = mapper.Map<OutlayMaterial>(model);
            entity.StatusId = 1;

            smartManagerServerUnitOfWork.OutlayMaterialRepository.Add(entity);

            await smartManagerServerUnitOfWork.SaveAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await smartManagerServerUnitOfWork.OutlayMaterialRepository.GetBaseAsync(id);
            if (entity == null) throw new Exception("OutlayMaterial not found! Id = " + id);

            entity.StatusId = 3;

            smartManagerServerUnitOfWork.OutlayMaterialRepository.Update(entity);
            await smartManagerServerUnitOfWork.SaveAsync();
        }

        public async Task<List<OutlayMaterialModel>> GetAllByObjectIdAsync(int objectId)
        {
            var outlayMaterials = await smartManagerServerUnitOfWork.OutlayMaterialRepository.GetAllByObjectId(objectId);
            if (outlayMaterials == null) return null;

            return mapper.Map<List<OutlayMaterialModel>>(outlayMaterials);
        }

        public async Task<OutlayMaterialModel> GetAsync(int id)
        {
            var entity = await smartManagerServerUnitOfWork.OutlayMaterialRepository.GetAsync(id);
            if (entity == null)
                throw new Exception("Entity not found");

            var model = mapper.Map<OutlayMaterialModel>(entity);

            return model;
        }
    }
}

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
    public class PayoutService : IPayoutService
    {
        private readonly ISmartManagerServerUnitOfWork smartManagerServerUnitOfWork;
        private IMapper mapper;
        public PayoutService(ISmartManagerServerUnitOfWork smartManagerServerUnitOfWork, IMapper mapper)
        {
            this.smartManagerServerUnitOfWork = smartManagerServerUnitOfWork;
            this.mapper = mapper;
        }
        public async Task<int> CreateAsync(PayoutModel model)
        {
            var entity = mapper.Map<Payout>(model);
            entity.Date = DateTime.Now;

            smartManagerServerUnitOfWork.PayoutRepository.Add(entity);
            await smartManagerServerUnitOfWork.SaveAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await smartManagerServerUnitOfWork.PayoutRepository.GetBaseAsync(id);
            if (entity == null) throw new Exception("Payout not found! id = " + id);

            smartManagerServerUnitOfWork.PayoutRepository.Remove(entity);
            await smartManagerServerUnitOfWork.SaveAsync();
        }

        public async Task<List<PayoutModel>> GetAllByObjectIdAsync(int objectId)
        {
            var entities = await smartManagerServerUnitOfWork.PayoutRepository.GetAllByObjectId(objectId);
            if (entities == null) return null;

            return mapper.Map<List<PayoutModel>>(entities);
        }

        public async Task<PayoutModel> GetAsync(int id)
        {
            var entity = await smartManagerServerUnitOfWork.PayoutRepository.GetAsync(id);
            if (entity == null)
                throw new Exception("Entity not found!");
            var model = mapper.Map<PayoutModel>(entity);

            return model;
        }
    }
}

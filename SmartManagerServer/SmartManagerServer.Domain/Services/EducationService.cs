using AutoMapper;
using SmartManagerServer.Core.UoWs;
using SmartManagerServer.Domain.Contracts.Services;
using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Domain.Services
{
    public class EducationService : IEducationService
    {
        private readonly ISmartManagerServerUnitOfWork smartManagerServerUnitOfWork;
        private IMapper mapper;
        public EducationService(ISmartManagerServerUnitOfWork smartManagerServerUnitOfWork, IMapper mapper)
        {
            this.smartManagerServerUnitOfWork = smartManagerServerUnitOfWork;
            this.mapper = mapper;
        }
        public async Task<List<EducationModel>> GetAllAsync()
        {
            var entities = await smartManagerServerUnitOfWork.IGenericEducationRepository.GetBaseAsync(x => x.Deleted == false);
            if (entities == null)
                return null;

            var models = mapper.Map<List<EducationModel>>(entities);

            return models;
        }
    }
}

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
    public class OutlayEmployeeService : IOutlayEmployeeService
    {
        private readonly ISmartManagerServerUnitOfWork smartManagerServerUnitOfWork;
        private IMapper mapper;
        public OutlayEmployeeService(ISmartManagerServerUnitOfWork smartManagerServerUnitOfWork, IMapper mapper)
        {
            this.smartManagerServerUnitOfWork = smartManagerServerUnitOfWork;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(OutlayEMployeeCreateFormModel model)
        {
            OutlayEmployee outlayEmployee = new OutlayEmployee()
            {
                EmployeeId = model.EmployeeId,
                ObjectId = model.ObjectId,
                Minutes = model.Minutes + model.Hours * 60,
                StatusId = 1,
                Date = DateTime.Now,
            };
            var employee = await smartManagerServerUnitOfWork.EmployeeRepository.GetAsync(model.EmployeeId);
            if (employee == null)
            {
                throw new Exception("EMployee not found!");
            }
            outlayEmployee.Price = (double)(employee.Salary / 60 * outlayEmployee.Minutes);

            smartManagerServerUnitOfWork.OutlayEmployeeRepository.Add(outlayEmployee);
            await smartManagerServerUnitOfWork.SaveAsync();

            return outlayEmployee.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await smartManagerServerUnitOfWork.OutlayEmployeeRepository.GetBaseAsync(id);
            if (entity == null) throw new Exception("OutlayMaterial not found! Id = " + id);

            entity.StatusId = 3;

            smartManagerServerUnitOfWork.OutlayEmployeeRepository.Update(entity);
            await smartManagerServerUnitOfWork.SaveAsync();
        }

        public async Task<List<OutlayEmployeeOutputModel>> GetAllByObjectIdAsync(int objectId)
        {
            var entities = await smartManagerServerUnitOfWork.OutlayEmployeeRepository.GetAllByObjectId(objectId);
            if (entities == null) return null;

            var models = new List<OutlayEmployeeOutputModel>();

            foreach (var entity in entities)
            {
                OutlayEmployeeOutputModel model = mapper.Map<OutlayEmployeeOutputModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public async Task<OutlayEmployeeOutputModel> GetAsync(int id)
        {
            var entity = await smartManagerServerUnitOfWork.OutlayEmployeeRepository.GetAsync(id);
            if (entity == null) return null;

            OutlayEmployeeOutputModel model = mapper.Map<OutlayEmployeeOutputModel>(entity);

            return model;
        }

        public async Task<OutlayEmployeeOutputModel> GetByEmployeeId(int employeeId, int objectId)
        {
            var entities = await smartManagerServerUnitOfWork.OutlayEmployeeRepository.GetByEmployeeId(employeeId, objectId);
            if (entities == null) return null;

            int time = 0;
            foreach (var entity in entities)
            {
                time += entity.Minutes;
            }

            var model = new OutlayEmployeeOutputModel();

            return model;
        }
    }
}

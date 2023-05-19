using AutoMapper;
using SmartManagerServer.Core.Entities.SmartManagerServer;
using SmartManagerServer.Core.Services;
using SmartManagerServer.Core.UoWs;
using SmartManagerServer.Domain.Contracts.Services;
using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ISmartManagerServerUnitOfWork smartManagerServerUnitOfWork;
        private readonly IFIleService fileService;
        private IMapper mapper;
        public EmployeeService(ISmartManagerServerUnitOfWork smartManagerServerUnitOfWork, IMapper mapper, IFIleService fIleService)
        {
            this.smartManagerServerUnitOfWork = smartManagerServerUnitOfWork;
            this.mapper = mapper;
            this.fileService = fIleService;
        }
        public async Task<int> CreateAsync(EmployeeModel employeeModel)
        {
            var entity = mapper.Map<Employee>(employeeModel);
            entity.CreatedDate = DateTime.Now;
            entity.StatusId = 1;
            entity.FullName = entity.FirstName + " " + entity.LastName;

            if (employeeModel.Image != null)
            {
                //Create image
                entity.ImageId = await CreatFileAsync(employeeModel.Image);
            }

            smartManagerServerUnitOfWork.EmployeeRepository.Add(entity);
            await smartManagerServerUnitOfWork.SaveAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await smartManagerServerUnitOfWork.EmployeeRepository.GetBaseAsync(id);
            if (entity == null) throw new Exception("Employee not found! ID = " + id);

            entity.StatusId = 3;

            smartManagerServerUnitOfWork.EmployeeRepository.Update(entity);
            await smartManagerServerUnitOfWork.SaveAsync();
        }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            var entities = await smartManagerServerUnitOfWork.EmployeeRepository.GetAll();
            if (entities == null) throw new Exception("Employee not found!");

            var models = mapper.Map<List<EmployeeModel>>(entities);

            foreach (var x in models)
            {
                if (x.Image != null)
                    x.Image = new FileModel()
                    {
                        Body = await fileService.GetImageBase64ByGuidNameAsync(x.Image.Name)
                    };
            }

            return models;
        }

        public async Task<EmployeeModel> GetAsync(int id)
        {
            var entity = await smartManagerServerUnitOfWork.EmployeeRepository.GetAsync(id);
            if (entity == null) throw new Exception("Employee not found!");

            var model = mapper.Map<EmployeeModel>(entity);

            if (entity.ImageId != null)
            {

                model.Image = new FileModel()
                {
                    Body = await fileService.GetImageBase64ByGuidNameAsync(entity.Image.GuidName)
                };
            }

            return model;
        }

        public async Task UpdateAsync(EmployeeModel employeeModel)
        {
            var entity = await smartManagerServerUnitOfWork.EmployeeRepository.GetBaseAsync(employeeModel.id);
            if (entity == null) throw new Exception("Employee not found! Id = " + employeeModel.id);

            mapper.Map(employeeModel, entity);
            entity.FullName = entity.FirstName + " " + entity.LastName;

            if (employeeModel.Image != null && (entity.ImageId == null || entity.ImageId != employeeModel.Image.id))
            {
                //Create image
                entity.ImageId = await CreatFileAsync(employeeModel.Image);
            } else if (employeeModel.Image == null && entity.ImageId != null)
            {
                entity.ImageId = null;
            }

            smartManagerServerUnitOfWork.EmployeeRepository.Update(entity);
            await smartManagerServerUnitOfWork.SaveAsync();
        }

        private async Task<int> CreatFileAsync(FileModel model)
        {
            var guidImageName = await fileService.CreateFileAsync(model.Body, model.OriginalName);

            File file = new File() { GuidName = guidImageName, OriginalName = model.OriginalName };

            smartManagerServerUnitOfWork.IGenericFileRepository.Add(file);
            await smartManagerServerUnitOfWork.SaveAsync();

            return file.Id;
        }

        private async Task<int> CreateImageAsync(FileModel model)
        {
            var guidImageName = await fileService.CreateImageAsync(model.Body, model.OriginalName);

            File file = new File() { GuidName = guidImageName, OriginalName = model.OriginalName };

            smartManagerServerUnitOfWork.IGenericFileRepository.Add(file);
            await smartManagerServerUnitOfWork.SaveAsync();

            return file.Id;
        }
    }
}

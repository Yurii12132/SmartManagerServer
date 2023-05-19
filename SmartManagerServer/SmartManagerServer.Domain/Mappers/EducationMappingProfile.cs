using AutoMapper;
using SmartManagerServer.Core.Entities.SmartManagerServer;
using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Domain.Mappers
{
    public class EducationMappingProfile : Profile
    {
        public EducationMappingProfile()
        {
            CreateMap<Education, EducationModel>();
        }
    }
}

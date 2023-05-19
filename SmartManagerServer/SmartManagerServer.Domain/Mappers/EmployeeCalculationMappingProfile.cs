using AutoMapper;
using SmartManagerServer.Core.Entities.SmartManagerServer;
using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Domain.Mappers
{
    public class EmployeeCalculationMappingProfile : Profile
    {
        public EmployeeCalculationMappingProfile()
        {
            CreateMap<EmployeeCalculation, EmployeeCalculationModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.TermOfWork, opt => opt.MapFrom(src => src.TermOfWork))
                .ForMember(dest => dest.Minutes, opt => opt.MapFrom(src => src.Minutes))
                .ForMember(dest => dest.Sum, opt => opt.MapFrom(src => src.Sum))
                .ForMember(dest => dest.PrepaidExpense, opt => opt.MapFrom(src => src.PrepaidExpense))
                .ForMember(dest => dest.ToBePaid, opt => opt.MapFrom(src => src.ToBePaid))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));


        }
    }
}

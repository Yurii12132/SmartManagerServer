using AutoMapper;
using SmartManagerServer.Core.Entities.SmartManagerServer;
using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Domain.Mappers
{
    public class PayoutMappingProfile : Profile
    {
        public PayoutMappingProfile()
        {
            CreateMap<Payout, PayoutModel>()
                .ForMember(dest => dest.ObjectName, opt => opt.MapFrom(src => src.Object.Name));

            CreateMap<PayoutModel, Payout>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Object, opt => opt.Ignore())
                .ForMember(dest => dest.ObjectId, opt => opt.MapFrom(src => src.ObjectId))
                .ForMember(dest => dest.Date, opt => opt.Ignore());
        }
    }
}

using AutoMapper;
using SmartManagerServer.Core.Entities.SmartManagerServer;
using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Domain.Mappers
{
    public class FileMappingProfile : Profile
    {
        public FileMappingProfile()
        {
            CreateMap<FileModel, File>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OriginalName, opt => opt.MapFrom(src => src.OriginalName))
                .ForMember(dest => dest.GuidName, opt => opt.MapFrom(src => src.Name));

            CreateMap<File, FileModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GuidName))
                .ForMember(dest => dest.OriginalName, opt => opt.MapFrom(src => src.OriginalName));
        }
    }
}

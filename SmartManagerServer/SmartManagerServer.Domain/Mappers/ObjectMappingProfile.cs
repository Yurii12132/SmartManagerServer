using AutoMapper;
using SmartManagerServer.Core.Entities.SmartManagerServer;
using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Object = SmartManagerServer.Core.Entities.SmartManagerServer.Object;

namespace SmartManagerServer.Domain.Mappers
{
    public class ObjectMappingProfile : Profile
    {
        public ObjectMappingProfile()
        {
            CreateMap<Core.Entities.SmartManagerServer.Object, ObjectModel>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CloseDate));

            CreateMap<ObjectModel, Core.Entities.SmartManagerServer.Object>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CloseDate));

            CreateMap<Core.Entities.SmartManagerServer.Object, ObjectInformationModel>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
                .ForMember(dest => dest.Documents, opt => opt.MapFrom(src => src.DocumentObject))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.ImageObject));

            CreateMap<ObjectInformationModel, Object>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<DocumentObject, FileModel>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.File.Id))
                .ForMember(dest => dest.OriginalName, opt => opt.MapFrom(src => src.File.OriginalName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.File.GuidName));

            CreateMap<ImageObject, FileModel>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.File.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.File.OriginalName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.File.GuidName));
        }
    }
}

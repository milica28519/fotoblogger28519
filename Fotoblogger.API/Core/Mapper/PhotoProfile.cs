using AutoMapper;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.API.Core.Mapper
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<Photo, PhotoDto>()
                .ForMember(dto => dto.ThumbnailPath, opt => opt.MapFrom(photo => photo.getThumbnailPhotoPath()))
                .ForMember(dto => dto.Path, opt => opt.MapFrom(photo => photo.getPhotoPath()))
                .ForMember(dto => dto.AverageScore, opt => opt.MapFrom(photo => photo.getAverageScore()));
            CreateMap<PhotoDto, Photo>();
        }
    }
}

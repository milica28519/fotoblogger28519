using AutoMapper;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.API.Core.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.FirstName, opt => opt.MapFrom(user => user.IsDeleted ? "Deleted" : (user.IsActive ? user.FirstName : "Deactivated")))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(user => user.IsDeleted || user.IsActive ? user.LastName : "User"))
                .ForMember(dto => dto.Username, opt => opt.MapFrom(user => user.IsDeleted ? ("DeletedUser" + user.Id) : (user.IsActive ? user.Username : ("DeactivatedUser" + user.Id))))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(user => user.IsDeleted || user.IsActive ? user.Email : ""))
                .ForMember(dto => dto.ProfilePhotoPath, opt => opt.MapFrom(user => user.IsActive ? user.getProfilePhotoPath() : null));

            CreateMap<User, UserPermissionsDto>()
                .ForMember(dto => dto.UserId, opt => opt.MapFrom(user => user.Id))
                .ForMember(dto => dto.AllowedUseCases, opt => opt.MapFrom(user => user.UseCases.Select(uc => uc.UseCase).ToList()));


            CreateMap<EditUserDto, User>();

            CreateMap<ChangeUserRoleDto, User>();

            CreateMap<ChangeUserUseCasesDto, User>()
               .ForMember(user => user.UseCases, opt => opt.Ignore())
               .AfterMap((dto, user) =>
               {
                   user.UseCases.Clear();
                   dto.AllowedUseCases.Distinct().ToList().ForEach(useCaseId => user.UseCases.Add(new UserUseCase { UserId = user.Id, UseCaseId = useCaseId }));
               });
        }
    }
}

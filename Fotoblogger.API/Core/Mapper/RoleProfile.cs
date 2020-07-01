using AutoMapper;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.API.Core.Mapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>()
                .ForMember(dto => dto.AllowedUseCases, opt => opt.MapFrom(role => role.RoleUseCases.Select(ruc => ruc.UseCase).ToList()));
            CreateMap<RoleDto, Role>();

            CreateMap<CreateRoleDto, Role>()
                .ForMember(role => role.RoleUseCases, opt => opt.MapFrom(dto => dto.AllowedUseCases.Distinct().Select(id => new RoleUseCase
                {
                    UseCaseId = id
                })));

            CreateMap<EditRoleDto, Role>()
               .ForMember(role => role.RoleUseCases, opt => opt.Ignore())
               .AfterMap((dto, role) =>
               {
                   role.RoleUseCases.Clear();
                   dto.AllowedUseCases.Distinct().ToList().ForEach(useCaseId => role.RoleUseCases.Add(new RoleUseCase{ RoleId = role.Id, UseCaseId = useCaseId }));
               });
        }
    }
}

using AutoMapper;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Exceptions;
using Fotoblogger.Application.Queries;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Queries
{
    public class EfGetRoleQuery : IGetRoleQuery
    {
        private readonly FotobloggerContext _context;
        private readonly IMapper _mapper;

        public EfGetRoleQuery(FotobloggerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 8;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public RoleDto Execute(int id)
        {
            var role = _context.Roles.Include(r => r.RoleUseCases).ThenInclude(ruc => ruc.UseCase).FirstOrDefault(p => p.Id == id);

            if (role == null)
                throw new EntityNotFoundException(id, typeof(Role));

            return _mapper.Map<RoleDto>(role);
        }
    }
}

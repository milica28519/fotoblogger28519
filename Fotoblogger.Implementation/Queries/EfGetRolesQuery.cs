using AutoMapper;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Queries;
using Fotoblogger.Application.Searches;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Queries
{
    public class EfGetRolesQuery : IGetRolesQuery
    {
        private readonly FotobloggerContext _context;
        private readonly IMapper _mapper;

        public EfGetRolesQuery(FotobloggerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 4;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public PagedResponse<RoleDto, Role> Execute(RoleSearch search)
        {
            var query = _context.Roles.Include(r => r.RoleUseCases).ThenInclude(r => r.UseCase).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) && !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(r => r.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return new PagedResponse<RoleDto, Role>(query, search, _mapper);
        }
    }
}

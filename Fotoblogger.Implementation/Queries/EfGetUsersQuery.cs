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
    public class EfGetUsersQuery : IGetUsersQuery
    {
        private readonly FotobloggerContext _context;
        private readonly IMapper _mapper;

        public EfGetUsersQuery(FotobloggerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 22;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public PagedResponse<UserDto, User> Execute(UserSearch search)
        {
            var query = _context.Users.Include(u => u.Role).Where(u => !u.IsDeleted && u.IsActive).AsQueryable();

            if (!string.IsNullOrEmpty(search.LastName) && !string.IsNullOrWhiteSpace(search.LastName))
                query = query.Where(u => u.LastName.ToLower().Contains(search.LastName.ToLower()));

            if (!string.IsNullOrEmpty(search.FirstName) && !string.IsNullOrWhiteSpace(search.FirstName))
                query = query.Where(u => u.FirstName.ToLower().Contains(search.FirstName.ToLower()));

            if (!string.IsNullOrEmpty(search.Username) && !string.IsNullOrWhiteSpace(search.Username))
                query = query.Where(u => u.Username.ToLower().Contains(search.Username.ToLower()));

            if (!string.IsNullOrEmpty(search.Email) && !string.IsNullOrWhiteSpace(search.Email))
                query = query.Where(u => u.Username.ToLower().Contains(search.Username.ToLower()));

            if (!string.IsNullOrEmpty(search.RoleName) && !string.IsNullOrWhiteSpace(search.RoleName))
                query = query.Where(u => u.Role.Name.ToLower().Contains(search.RoleName.ToLower()));

            return new PagedResponse<UserDto, User>(query, search, _mapper);
        }
    }
}

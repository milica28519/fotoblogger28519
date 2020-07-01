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
    public class EfGetUserQuery : IGetUserQuery
    {
        private readonly FotobloggerContext _context;
        private readonly IMapper _mapper;

        public EfGetUserQuery(FotobloggerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 21;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public UserDto Execute(int id)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => !u.IsDeleted && u.Id == id);

            if (user == null)
                throw new EntityNotFoundException(id, typeof(User));

            return _mapper.Map<UserDto>(user);
        }
    }
}

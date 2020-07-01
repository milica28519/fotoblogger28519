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
    public class EfGetPostQuery : IGetPostQuery
    {
        private readonly FotobloggerContext _context;
        private readonly IMapper _mapper;

        public EfGetPostQuery(FotobloggerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 11;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public PostDto Execute(int id)
        {
            var post = _context.Posts.Include(p => p.Photo).FirstOrDefault(p => p.Id == id);

            if (post == null)
                throw new EntityNotFoundException(id, typeof(Role));

            return _mapper.Map<PostDto>(post);
        }
    }
}

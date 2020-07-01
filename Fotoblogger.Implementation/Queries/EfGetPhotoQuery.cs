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
    public class EfGetPhotoQuery : IGetPhotoQuery
    {
        private readonly FotobloggerContext _context;
        private readonly IMapper _mapper;

        public EfGetPhotoQuery(FotobloggerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 13;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public PhotoDto Execute(int id)
        {
            var post = _context.Photos.Include(p => p.Post).FirstOrDefault(p => p.Id == id);

            if (post == null)
                throw new EntityNotFoundException(id, typeof(Photo));

            return _mapper.Map<PhotoDto>(post);
        }
    }
}

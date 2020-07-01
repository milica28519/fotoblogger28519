using AutoMapper;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Exceptions;
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
    public class EfGetPostCommentsQuery : IGetPostCommentsQuery
    {
        private readonly FotobloggerContext _context;
        private readonly IMapper _mapper;

        public EfGetPostCommentsQuery(FotobloggerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 19;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public PagedResponse<PostCommentDto, Comment> Execute(PostCommentSearch search)
        {
            if (_context.Posts.Find(search.PostId) == null)
                throw new EntityNotFoundException(search.PostId, typeof(Post));

            // show only parent comments and they will show information of number of child comments that will be accessable thorugh anotehr action (show all replies to comment)
            var query = _context.Comments.Include(c => c.ChildComments).Where(c => c.PostId == search.PostId && c.ParentId == null).AsQueryable();

            return new PagedResponse<PostCommentDto, Comment>(query, search, _mapper);
        }
    }
}

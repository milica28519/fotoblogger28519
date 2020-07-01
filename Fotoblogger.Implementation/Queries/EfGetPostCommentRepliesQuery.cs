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
    public class EfGetPostCommentRepliesQuery : IGetPostCommentRepliesQuery
    {
        private readonly FotobloggerContext _context;
        private readonly IMapper _mapper;

        public EfGetPostCommentRepliesQuery(FotobloggerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 20;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public PagedResponse<PostCommentDto, Comment> Execute(PostCommentRepliesSearch search)
        {
            if (_context.Posts.Find(search.PostId) == null)
                throw new EntityNotFoundException(search.PostId, typeof(Post));

            var query = _context.Comments
                .Include(c => c.ChildComments)
                .Where(c => c.PostId == search.PostId && c.ParentId == search.CommentId).AsQueryable();

            return new PagedResponse<PostCommentDto, Comment>(query, search, _mapper);
        }
    }
}

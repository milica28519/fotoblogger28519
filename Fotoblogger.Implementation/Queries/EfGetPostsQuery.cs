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
    public class EfGetPostsQuery : IGetPostsQuery
    {
        private readonly FotobloggerContext _context;
        private readonly IMapper _mapper;

        public EfGetPostsQuery(FotobloggerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 1;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public PagedResponse<PostDto, Post> Execute(PostSearch search)
        {
            var query = _context.Posts.Include(p => p.Photo).AsQueryable();

            if (!string.IsNullOrEmpty(search.Title) && !string.IsNullOrWhiteSpace(search.Title))
            {
                query = query.Where(g => g.Title.ToLower().Contains(search.Text.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Text) && !string.IsNullOrWhiteSpace(search.Text))
            {
                query = query.Where(g => g.Text.ToLower().Contains(search.Text.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.PhotoCaption) && !string.IsNullOrWhiteSpace(search.PhotoCaption))
            {
                query = query.Where(g => g.Photo.Caption.ToLower().Contains(search.PhotoCaption.ToLower()));
            }

            query = query.OrderByDescending(x => x.CreatedAt);

            return new PagedResponse<PostDto, Post>(query, search, _mapper);
        }
    }
}

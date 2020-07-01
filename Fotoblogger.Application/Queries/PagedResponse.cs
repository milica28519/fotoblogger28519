using AutoMapper;
using AutoMapper.QueryableExtensions.Impl;
using Fotoblogger.Application.Searches;
using Fotoblogger.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Fotoblogger.Application.Queries
{
    public interface IData<T>
    {
        T Data { get; set; }
    }

    public class PagedResponse<T1, T2> where T1 : class, new()
    {
        public int TotalCount { get; set; } 
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public IEnumerable<T1> Items { get; set; }

        public int PagesCount => (int)Math.Ceiling((float)TotalCount / ItemsPerPage);

        public PagedResponse(IQueryable<T2> query, PagedSearch search, IMapper mapper)
        {
            TotalCount = query.Count();
            CurrentPage = search.Page;
            ItemsPerPage = search.PerPage;
            Items = mapper.Map<IEnumerable<T1>>(
                query
                .Skip(search.Skip())
                .Take(search.PerPage)
                .ToList()
                );
        }
    }

}

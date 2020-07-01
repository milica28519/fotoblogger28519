﻿using AutoMapper;
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
    public class EfGetPhotosQuery : IGetPhotosQuery
    {
        private readonly FotobloggerContext _context;
        private readonly IMapper _mapper;

        public EfGetPhotosQuery(FotobloggerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 12;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public PagedResponse<PhotoDto, Photo> Execute(PhotoSearch search)
        {
            var query = _context.Photos.Include(p => p.Post).AsQueryable();

            if (!string.IsNullOrEmpty(search.PhotoCaption) && !string.IsNullOrWhiteSpace(search.PhotoCaption))
            {
                query = query.Where(g => g.Caption.ToLower().Contains(search.PhotoCaption.ToLower()));
            }

            query = query.OrderByDescending(x => x.getAverageScore());

            return new PagedResponse<PhotoDto, Photo>(query, search, _mapper);
        }
    }
}

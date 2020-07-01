using AutoMapper;
using Fotoblogger.Application;
using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Exceptions;
using Fotoblogger.Application.Queries;
using Fotoblogger.Application.Searches;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Implementation.Queries
{
    public class EfGetUseCaseLogsQuery : IGetUseCaseLogsQuery
    {
        private readonly FotobloggerContext _context;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;

        public EfGetUseCaseLogsQuery(FotobloggerContext context, IMapper mapper, IApplicationActor actor)
        {
            _context = context;
            _mapper = mapper;
            _actor = actor;
        }

        public int Id => 34;
        public string Name => UseCase.UseCaseDictionary[this.Id];

        public PagedResponse<UseCaseLogDto, UseCaseLog> Execute(UseCaseLogSearch search)
        {
            if(_actor.RoleType != RoleType.Administrator && _actor.RoleType != RoleType.Moderator)
                throw new NotAllowedException(UseCase.getUseCase(this.Id), _actor, "Only administrator and moderator can execute this action.");

            var query = _context.UseCaseLogs.AsQueryable();

            if (search.UseCaseId != 0)
                query = query.Where(r => r.UseCaseId == search.UseCaseId);

            if (!string.IsNullOrEmpty(search.Data) && !string.IsNullOrWhiteSpace(search.Data))
                query = query.Where(r => r.Data.ToLower().Contains(search.Data.ToLower()));

            if (!string.IsNullOrEmpty(search.UseCaseName) && !string.IsNullOrWhiteSpace(search.UseCaseName))
                query = query.Where(r => r.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));

            if (!string.IsNullOrEmpty(search.Actor) && !string.IsNullOrWhiteSpace(search.Actor))
                query = query.Where(r => r.Actor.ToLower().Contains(search.Actor.ToLower()));

            if (!string.IsNullOrEmpty(search.DateFrom) && !string.IsNullOrWhiteSpace(search.DateFrom))
                query = query.Where(r => r.Date.Date >= DateTime.Parse(search.DateFrom));

            if (!string.IsNullOrEmpty(search.DateTo) && !string.IsNullOrWhiteSpace(search.DateTo))
                query = query.Where(r => r.Date.Date <= DateTime.Parse(search.DateTo));

            query = query;

            return new PagedResponse<UseCaseLogDto, UseCaseLog>(query, search, _mapper);
        }
    }
}

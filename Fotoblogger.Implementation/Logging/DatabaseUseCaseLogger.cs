using Fotoblogger.Application;
using Fotoblogger.Domain.Entities;
using Fotoblogger.EfDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly FotobloggerContext _context;

        public DatabaseUseCaseLogger(FotobloggerContext context) => _context = context;

        public void log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name,
                UseCaseId = useCase.Id
            });

            _context.SaveChanges();
        }
    }
}

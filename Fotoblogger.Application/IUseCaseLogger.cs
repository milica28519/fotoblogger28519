using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application
{
    public interface IUseCaseLogger
    {
        void log(IUseCase useCase, IApplicationActor actor, object useCaseData);
    }
}

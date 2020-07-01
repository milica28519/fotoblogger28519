using Fotoblogger.Application.Queries;
using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fotoblogger.Application
{
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }

    public interface IQuery<TSearch, TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }

}

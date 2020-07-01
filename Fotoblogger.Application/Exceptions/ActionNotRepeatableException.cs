using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.Exceptions
{
    public class ActionNotRepeatableException : Exception
    {
        public ActionNotRepeatableException(IUseCase useCase, IApplicationActor actor)
            : base($"Actor {actor.Id} - {actor.Identity} is trying to exeucte action {useCase.Id} - {useCase.Name} which is non-repeatable.")
        {

        }
    }
}

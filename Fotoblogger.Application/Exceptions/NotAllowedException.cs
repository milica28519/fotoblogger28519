using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.Exceptions
{
    public class NotAllowedException : Exception
    {
        private string _details;
        public NotAllowedException(IUseCase useCase, IApplicationActor actor, string details = "")
            : base($"Actor with an id of {actor.Id} - {actor.Identity} tried to execute {useCase.Id} - {useCase.Name} that requires administrator or moderator role.")
        {
            _details = details;
        }
        public string getDetails()
        {
            return _details;
        }
    }
}

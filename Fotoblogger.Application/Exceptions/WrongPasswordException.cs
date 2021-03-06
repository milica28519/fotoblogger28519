﻿using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.Exceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException(IUseCase useCase, IApplicationActor actor)
            : base($"Actor with an id of {actor.Id} - {actor.Identity} tried to execute {useCase.Id} - {useCase.Name} with unsuccessful password confirmation.")
        {

        }
    }
}

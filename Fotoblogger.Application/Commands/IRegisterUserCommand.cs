using Fotoblogger.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.Commands
{
    public interface IRegisterUserCommand : ICommand<RegisterUserDto>
    {
    }
}

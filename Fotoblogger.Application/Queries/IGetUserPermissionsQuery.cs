using Fotoblogger.Application.DataTransfer;
using Fotoblogger.Application.Searches;
using Fotoblogger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fotoblogger.Application.Queries
{
    public interface IGetUserPermissionsQuery : IQuery<int, UserPermissionsDto>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Fotoblogger.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        // single key PK
        public EntityNotFoundException(int id, Type type)
            : base($"Entity of type {type.Name} with an id of {id} was not found.")
        {
        }

        // composite key PK
        public EntityNotFoundException(int[] ids, Type type)
            : base($"Entity of type {type.Name} with an id of ({string.Join(",", ids)}) was not found.")
        {
        }
    }
}

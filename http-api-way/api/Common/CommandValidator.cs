using api.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Common
{
    public class CommandValidator<TCommand>
        : ICommandValidator<TCommand>
    {
        public Task<IList<IError>> Validate(TCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

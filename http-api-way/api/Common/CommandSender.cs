using api.Infrastructure;
using System;
using System.Threading.Tasks;

namespace api.Common
{
    public class CommandSender<TCommand>
        : ICommandSender<TCommand>
    {
        public Task<IStepProcessResult> Send(TCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

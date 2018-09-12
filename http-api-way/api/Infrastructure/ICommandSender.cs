using System.Threading.Tasks;

namespace api.Infrastructure
{
    public interface ICommandSender<TCommand>
    {
        Task<IStepProcessResult> Send(TCommand command);
    }
}

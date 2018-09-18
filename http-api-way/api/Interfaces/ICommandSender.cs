using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface ICommandSender<TCommand>
    {
        Task<IStepProcessResult> Send(TCommand command);
    }
}

using System.Threading.Tasks;

namespace api.Infrastructure
{
    public interface IStepProcessTemplate<TStepModel, TCommand>
    {
        Task<IStepProcessResult> Process(TStepModel step, TCommand command);
    }
}

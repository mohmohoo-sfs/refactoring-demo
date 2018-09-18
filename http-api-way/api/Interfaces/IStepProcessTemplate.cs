using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IStepProcessTemplate<TStepModel, TCommand>
    {
        Task<IStepProcessResult> Process(TStepModel step, TCommand command);
    }
}

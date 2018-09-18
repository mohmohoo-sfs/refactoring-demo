using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface ICommandValidator<in TCommand>
    {
        Task<IList<IError>> Validate(TCommand command);
    }
}

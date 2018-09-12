using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Infrastructure
{
    public interface ICommandValidator<in TCommand>
    {
        Task<IList<IError>> Validate(TCommand command);
    }
}

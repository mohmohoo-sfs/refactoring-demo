using System;
using System.Collections.Generic;

namespace api.Infrastructure
{
    public interface IOnErrorCallBackHolder<ReturnType>
    {
        ReturnType OnError(Action<IList<IError>> onError);
    }
}

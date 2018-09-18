using System;
using System.Collections.Generic;

namespace api.Interfaces
{
    public interface IOnErrorCallBackHolder<ReturnType>
    {
        ReturnType OnError(Action<IList<IError>> onError);
    }
}

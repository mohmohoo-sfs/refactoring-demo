using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Extensions; 

namespace api.Controllers
{
    public abstract class ControllerBase
       : Controller
    {
        protected ControllerBase()
        {
        }

        protected async Task<IActionResult> DoStep<TStepModel, TCommand>(
            IProductStep<TStepModel, IIncomeProductionApplication, TCommand> step, 
            TCommand command, 
            TStepModel model)
            where TCommand : class
        {
            var template = step.GetTemplate();
            var result = await template.Process(model, command);
            return result.ToActionResult(this);
        }

        protected void OnError(IList<IError> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(error.MemberName, error.Message);
            }
        }
    }
}

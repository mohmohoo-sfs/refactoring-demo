using api.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace api.Extensions
{
    public static class StepProcessResultExtensions
    {
        public static IActionResult ToActionResult(this IStepProcessResult stepProcessResult, Controller controller)
        {
            if (stepProcessResult.IsSuccess)
            {
                return controller.Ok(new { stepProcessResult.Id, stepProcessResult.Version });
            }

            return controller.BadRequest();
        }
    }
}

using api.Interfaces;
using api.Products.IncomeProtection;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers.v1
{
    [Route("products/incomeprotection/application/v1")]
    public class IncomeProtectionController
        : ControllerBase
    {
        private IIncomeProductionStep<IApplicationStep1Model, IStep1Command> _step1;
        private IIncomeProductionStep<IApplicationStep2Model, IStep2Command> _step2;

        public IncomeProtectionController(
            IIncomeProductionStep<IApplicationStep1Model, IStep1Command> step1,
            IIncomeProductionStep<IApplicationStep2Model, IStep2Command> step2)
            : base()
        {
            _step1 = step1.OnError(OnError);
            _step2 = step2.OnError(OnError);
        }

        [HttpPost(template: "post/step1")]
        public async Task<IActionResult> Step1(IApplicationStep1Model model)
        {
            return await DoStep(_step1, new Step1Command(model), model);
        }

        [HttpPost(template: "post/step2")]
        public async Task<IActionResult> Step2(IApplicationStep2Model model)
        {
            return await DoStep(_step2, new Step2Command(model), model);
        }
    }
}

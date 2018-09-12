using api.GraphQL;
using api.GraphQL.Models;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers.IncomeProtection
{
    [Route("v1/[controller]")]
    public class IncomeProtectionController
        : GraphQLControllerBase
    {
        public IncomeProtectionController(IncomeProtectionV1Schema schema, IDocumentExecuter documentExecuter)
            : base(schema, documentExecuter)
        {
        }

        [HttpPost]
        public override async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            return await base.Post(query);
        }
    }
}

using api.GraphQL;
using api.GraphQL.Models;
using GraphQL;
using GraphQL.Types;
using GraphQL.Validation.Complexity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class GraphQLControllerBase : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQLControllerBase(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        public virtual async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs,
                ExposeExceptions = false,
                ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 } // to prevent DoS attacks
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);
            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }

}

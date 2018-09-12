using api.GraphQL.Models.Outputs;
using GraphQL.Types;

namespace api.GraphQL.Queries
{
    public class IncomeProtectionQuery : ObjectGraphType
    {
        public IncomeProtectionQuery()
        {
            Field<StepResponseModelType>(
                "step1",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => new StepResponseModelType());
        }
    }
}

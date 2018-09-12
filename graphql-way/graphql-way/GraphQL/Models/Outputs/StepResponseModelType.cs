using api.Models;
using GraphQL.Types;

namespace api.GraphQL.Models.Outputs
{
    public class StepResponseModelType : ObjectGraphType<StepResponseModel>
    {
        public StepResponseModelType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Unique Identifier");
            Field(x => x.Version).Description("Version number");
        }
    }
}

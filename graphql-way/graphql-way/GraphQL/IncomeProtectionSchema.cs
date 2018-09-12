using api.GraphQL.Mutations;
using api.GraphQL.Queries;
using GraphQL;
using GraphQL.Types;

namespace api.GraphQL
{
    public class IncomeProtectionV1Schema : Schema 
    {
        public IncomeProtectionV1Schema(IDependencyResolver resolver)
           : base(resolver)
        {
            Query = resolver.Resolve<IncomeProtectionQuery>();
            Mutation = resolver.Resolve<IncomeProtectionMutation>();
        }
    }
}

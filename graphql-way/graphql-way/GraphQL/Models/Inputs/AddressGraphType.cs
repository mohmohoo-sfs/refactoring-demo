using GraphQL.Types;

namespace api.GraphQL.Models.Inputs
{
    public class AddressGraphType : InputObjectGraphType
    {
        public AddressGraphType()
        {
            Field<StringGraphType>("Line1");
            Field<StringGraphType>("Line2");
            Field<StringGraphType>("City");
            Field<StringGraphType>("County");
            Field<StringGraphType>("PostCode");
        }
    }
}

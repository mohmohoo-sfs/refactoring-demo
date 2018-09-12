using GraphQL.Types;

namespace api.GraphQL.Models.Inputs
{
    public class Step1InputType : InputObjectGraphType
    {
        public Step1InputType()
        {
            Name = "Step1Input";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<StringGraphType>("forename");
            Field<StringGraphType>("surname");
            Field<DateTimeGraphType>("dob");
            Field<GenderEnum>("Gender");
            Field<StringGraphType>("Telephone");
            Field<StringGraphType>("Email");
            Field<StringGraphType>("NationalInsuranceNumber");
            Field<StringGraphType>("Source");
            Field<StringGraphType>("Campaign");
        }
    }
}

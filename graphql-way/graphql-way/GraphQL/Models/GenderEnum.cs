using GraphQL.Types;

namespace api.GraphQL.Models
{
    public class GenderEnum : EnumerationGraphType
    {
        public GenderEnum()
        {
            Name = "gender";
            AddValue("MALE", string.Empty, "Male");
            AddValue("FEMALE", string.Empty, "Female");
        }
    }
}

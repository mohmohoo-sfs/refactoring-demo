using System;

namespace api.Interfaces
{
    public interface IStep1Command
    {
        string Title { get; }
        string Forename { get; }
        string Surname { get; }
        DateTime? Dob { get; }
        string Gender { get; }
        string Telephone { get; }
        string Email { get; }
        string NationalInsuranceNumber { get; }
        string Source { get; }
        string Campaign { get; }
    }
}

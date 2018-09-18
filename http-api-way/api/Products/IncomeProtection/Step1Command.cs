using api.Interfaces;
using System;

namespace api.Products.IncomeProtection
{
    public class Step1Command
        : IStep1Command
    {
        public string Title { get; }
        public string Forename { get; }
        public string Surname { get; }
        public DateTime? Dob { get; }
        public string Gender { get; }
        public string Telephone { get; }
        public string Email { get; }
        public string NationalInsuranceNumber { get; }
        public string Source { get; }
        public string Campaign { get; }

        public Step1Command(IApplicationStep1Model model)
        {
        }
    }
}

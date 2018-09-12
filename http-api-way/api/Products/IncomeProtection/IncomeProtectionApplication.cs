using api.Infrastructure;
using System;

namespace api.Products.IncomeProtection
{
    public class IncomeProtectionApplication
        : IIncomeProductionApplication
    {
        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public string Source { get; set; }
        public string Campaign { get; set; }
    }
}

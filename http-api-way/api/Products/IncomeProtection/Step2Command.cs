using api.Interfaces;

namespace api.Products.IncomeProtection
{
    public class Step2Command
        : IStep2Command
    {
        public bool? UkResident { get; }
        public bool? RegisteredWithaUKMedicalPractise { get; }
        public bool? UkTaxPayer { get; }
        public bool? UkBankAccount { get; }
        public bool? Homeowner { get; }
        public bool? OtherDeclinedOrAcceptedOtherThanNormalTerms { get; }
        public string OtherDeclinedOrAcceptedOtherThanNormalTermsDetails { get; }
        public bool? InsuredElsewhere { get; }
        public string InsuredElsewhereDetails { get; }
        public string InsuredElsewhereCompanyName { get; }
        public int? InsuredElsewhereAmountOfBenefit { get; }
        public string InsuredElsewhereAmountOfBenefitFrequency { get; }
        public bool? InsuredElsewhereContinue { get; }
        public bool? PreviousProtectionClaims { get; }
        public string PreviousProtectionClaimsDetails { get; }
        public bool? PreviousInjuryClaims { get; }
        public string PreviousInjuryClaimsDetails { get; }

        public Step2Command(IApplicationStep2Model model)
        {

        }
    }
}

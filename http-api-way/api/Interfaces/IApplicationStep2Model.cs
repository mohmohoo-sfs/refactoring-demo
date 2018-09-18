namespace api.Interfaces
{
    public interface IApplicationStep2Model
    {
        bool? UkResident { get; set; }
        bool? RegisteredWithaUKMedicalPractise { get; set; }
        bool? UkTaxPayer { get; set; }
        bool? UkBankAccount { get; set; }
        bool? Homeowner { get; set; }

        bool? OtherDeclinedOrAcceptedOtherThanNormalTerms { get; set; }
        string OtherDeclinedOrAcceptedOtherThanNormalTermsDetails { get; set; }

        bool? InsuredElsewhere { get; set; }
        string InsuredElsewhereDetails { get; set; }
        string InsuredElsewhereCompanyName { get; set; }
        int? InsuredElsewhereAmountOfBenefit { get; set; }
        string InsuredElsewhereAmountOfBenefitFrequency { get; set; }
        bool? InsuredElsewhereContinue { get; set; }

        bool? PreviousProtectionClaims { get; set; }
        string PreviousProtectionClaimsDetails { get; set; }

        bool? PreviousInjuryClaims { get; set; }
        string PreviousInjuryClaimsDetails { get; set; }
    }
}

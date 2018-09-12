namespace api.Infrastructure
{
    public interface IStep2Command
    {
        bool? UkResident { get; }
        bool? RegisteredWithaUKMedicalPractise { get; }
        bool? UkTaxPayer { get; }
        bool? UkBankAccount { get; }
        bool? Homeowner { get; }

        bool? OtherDeclinedOrAcceptedOtherThanNormalTerms { get; }
        string OtherDeclinedOrAcceptedOtherThanNormalTermsDetails { get; }

        bool? InsuredElsewhere { get; }
        string InsuredElsewhereDetails { get; }
        string InsuredElsewhereCompanyName { get; }
        int? InsuredElsewhereAmountOfBenefit { get; }
        string InsuredElsewhereAmountOfBenefitFrequency { get; }
        bool? InsuredElsewhereContinue { get; }

        bool? PreviousProtectionClaims { get; }
        string PreviousProtectionClaimsDetails { get; }

        bool? PreviousInjuryClaims { get; }
        string PreviousInjuryClaimsDetails { get; }
    }
}

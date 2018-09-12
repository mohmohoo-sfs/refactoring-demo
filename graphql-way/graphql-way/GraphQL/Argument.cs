using api.GraphQL.Models;
using api.GraphQL.Models.Inputs;
using GraphQL.Types;

namespace api.GraphQL
{
    public static class Argument
    {
        public static QueryArgument<StringGraphType> Title => new QueryArgument<StringGraphType>
        {
            Name = "title",
            Description = "Title of the applicant",
            DefaultValue = "Default value"
        };

        public static QueryArgument<StringGraphType> Forename => new QueryArgument<StringGraphType>
        {
            Name = "forename",
            Description = "Forename of the applicant",
            DefaultValue = "Default value"
        };

        public static QueryArgument<StringGraphType> Surname => new QueryArgument<StringGraphType>
        {
            Name = "surname",
            Description = "Surname of the applicant",
            DefaultValue = "Default value"
        };

        public static QueryArgument<DateTimeGraphType> Dob => new QueryArgument<DateTimeGraphType>
        {
            Name = "dob",
            Description = "Birth date of the applicant"
        };

        public static QueryArgument<GenderEnum> Gender => new QueryArgument<GenderEnum>
        {
            Name = "gender",
            Description = "gender of the applicant"
        };

        public static QueryArgument<StringGraphType> Telephone => new QueryArgument<StringGraphType>
        {
            Name = "telephone",
            Description = "gender of the applicant"
        };

        public static QueryArgument<StringGraphType> Email => new QueryArgument<StringGraphType>
        {
            Name = "email",
            Description = "email of the applicant"
        };

        public static QueryArgument<AddressGraphType> Address => new QueryArgument<AddressGraphType>
        {
            Name = "Address",
            Description = "address of the applicant"
        };

        public static QueryArgument<NonNullGraphType<StringGraphType>> NationalInsuranceNumber => new QueryArgument<NonNullGraphType<StringGraphType>>
        {
            Name = "nationalInsuranceNumber",
            Description = "National insurance number of the applicant"
        };

        public static QueryArgument<StringGraphType> Source => new QueryArgument<StringGraphType>
        {
            Name = "source",
            Description = "Source"
        };

        public static QueryArgument<NonNullGraphType<StringGraphType>> Campaign => new QueryArgument<NonNullGraphType<StringGraphType>>
        {
            Name = "Campaign",
            Description = "Campaign",
            DefaultValue = "Campaign default value"
        };

        public static QueryArgument<BooleanGraphType> UkResident => new QueryArgument<BooleanGraphType>
        {
            Name = "UkResident",
            Description = "UkResident", 
            DefaultValue = true
        };

        public static QueryArgument<BooleanGraphType> RegisteredWithaUKMedicalPractise => new QueryArgument<BooleanGraphType>
        {
            Name = "RegisteredWithaUKMedicalPractise",
            Description = "RegisteredWithaUKMedicalPractise",
            DefaultValue = true
        };

        public static QueryArgument<BooleanGraphType> UkTaxPayer => new QueryArgument<BooleanGraphType>
        {
            Name = "UkTaxPayer",
            Description = "UkTaxPayer",
            DefaultValue = true
        };

        public static QueryArgument<BooleanGraphType> UkBankAccount => new QueryArgument<BooleanGraphType>
        {
            Name = "UkBankAccount",
            Description = "UkBankAccount",
            DefaultValue = true
        };

        public static QueryArgument<BooleanGraphType> Homeowner => new QueryArgument<BooleanGraphType>
        {
            Name = "Homeowner",
            Description = "Homeowner",
            DefaultValue = true
        };

        public static QueryArgument<BooleanGraphType> OtherDeclinedOrAcceptedOtherThanNormalTerms => new QueryArgument<BooleanGraphType>
        {
            Name = "OtherDeclinedOrAcceptedOtherThanNormalTerms",
            Description = "OtherDeclinedOrAcceptedOtherThanNormalTerms",
            DefaultValue = true
        };

        public static QueryArgument<StringGraphType> OtherDeclinedOrAcceptedOtherThanNormalTermsDetails => new QueryArgument<StringGraphType>
        {
            Name = "OtherDeclinedOrAcceptedOtherThanNormalTermsDetails",
            Description = "OtherDeclinedOrAcceptedOtherThanNormalTermsDetails",
            DefaultValue = "OtherDeclinedOrAcceptedOtherThanNormalTermsDetails default"
        };

        public static QueryArgument<BooleanGraphType> InsuredElsewhere => new QueryArgument<BooleanGraphType>
        {
            Name = "InsuredElsewhere",
            Description = "InsuredElsewhere",
            DefaultValue = true
        };

        public static QueryArgument<StringGraphType> InsuredElsewhereDetails => new QueryArgument<StringGraphType>
        {
            Name = "InsuredElsewhereDetails",
            Description = "InsuredElsewhereDetails",
            DefaultValue = "InsuredElsewhereDetails default value"
        };

        public static QueryArgument<StringGraphType> InsuredElsewhereCompanyName => new QueryArgument<StringGraphType>
        {
            Name = "InsuredElsewhereCompanyName",
            Description = "InsuredElsewhereCompanyName",
            DefaultValue = "InsuredElsewhereCompanyName default value"
        };

        public static QueryArgument<IntGraphType> InsuredElsewhereAmountOfBenefit => new QueryArgument<IntGraphType>
        {
            Name = "InsuredElsewhereAmountOfBenefit",
            Description = "InsuredElsewhereAmountOfBenefit",
            DefaultValue = 1
        };

        public static QueryArgument<StringGraphType> InsuredElsewhereAmountOfBenefitFrequency => new QueryArgument<StringGraphType>
        {
            Name = "InsuredElsewhereAmountOfBenefitFrequency",
            Description = "InsuredElsewhereAmountOfBenefitFrequency",
            DefaultValue = "InsuredElsewhereAmountOfBenefitFrequency default value"
        };

        public static QueryArgument<BooleanGraphType> InsuredElsewhereContinue => new QueryArgument<BooleanGraphType>
        {
            Name = "InsuredElsewhereContinue",
            Description = "InsuredElsewhereContinue",
            DefaultValue = true
        };

        public static QueryArgument<BooleanGraphType> PreviousProtectionClaims => new QueryArgument<BooleanGraphType>
        {
            Name = "PreviousProtectionClaims",
            Description = "PreviousProtectionClaims",
            DefaultValue = true
        };

        public static QueryArgument<StringGraphType> PreviousProtectionClaimsDetails => new QueryArgument<StringGraphType>
        {
            Name = "PreviousProtectionClaimsDetails",
            Description = "PreviousProtectionClaimsDetails",
            DefaultValue = "PreviousProtectionClaimsDetails default value"
        };

        public static QueryArgument<BooleanGraphType> PreviousInjuryClaims => new QueryArgument<BooleanGraphType>
        {
            Name = "PreviousInjuryClaims",
            Description = "PreviousInjuryClaims",
            DefaultValue = true
        };

        public static QueryArgument<StringGraphType> PreviousInjuryClaimsDetails => new QueryArgument<StringGraphType>
        {
            Name = "PreviousInjuryClaimsDetails",
            Description = "PreviousInjuryClaimsDetails",
            DefaultValue = "PreviousInjuryClaimsDetails default value"
        };
    }
}

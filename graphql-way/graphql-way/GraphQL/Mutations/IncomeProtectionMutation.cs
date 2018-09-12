using api.GraphQL.Models.Outputs;
using api.Models;
//using GraphQL;
using GraphQL.Types;

namespace api.GraphQL.Mutations
{
    public class IncomeProtectionMutation : ObjectGraphType
    {
        public IncomeProtectionMutation()
        {
            Name = "IncomeProtectionStepsMutation";
            Description = "Save partial application data";
            Field<StepResponseModelType>(
                "Step1",
                description: "Save step1 data",
                arguments: new QueryArguments(
                    //new QueryArgument<Step1InputType> { Name = "input" },
                    Argument.Title,
                    Argument.Forename,
                    Argument.Surname,
                    Argument.Dob,
                    Argument.Gender,
                    Argument.Telephone,
                    Argument.Email,
                    Argument.NationalInsuranceNumber,
                    Argument.Source,
                    Argument.Campaign),

                resolve: context => {
                    var title = context.GetArgument<string>("title");
                    // GraphQL-dotnet can also do asyn/await 
                    // https://github.com/graphql-dotnet/graphql-dotnet/issues/695
                    return new StepResponseModel
                    {
                        Id = new System.Guid(),
                        Version = 1
                    };
                });

            Field<StepResponseModelType>(
                "Step2",
                description: "Save step 2 data",
                arguments: new QueryArguments(
                    Argument.UkResident,
                    Argument.RegisteredWithaUKMedicalPractise,
                    Argument.UkTaxPayer,
                    Argument.UkBankAccount,
                    Argument.Homeowner,
                    Argument.OtherDeclinedOrAcceptedOtherThanNormalTerms,
                    Argument.OtherDeclinedOrAcceptedOtherThanNormalTermsDetails,
                    Argument.InsuredElsewhere,
                    Argument.InsuredElsewhereDetails,
                    Argument.InsuredElsewhereCompanyName,
                    Argument.InsuredElsewhereAmountOfBenefit,
                    Argument.InsuredElsewhereAmountOfBenefitFrequency,
                    Argument.InsuredElsewhereContinue,
                    Argument.PreviousProtectionClaims,
                    Argument.PreviousProtectionClaimsDetails,
                    Argument.PreviousInjuryClaims,
                    Argument.PreviousProtectionClaimsDetails),
                resolve: context => {
                    return new StepResponseModel
                    {
                        Id = new System.Guid(),
                        Version = 2
                    };
                });
        }
    }
}

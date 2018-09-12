namespace api.Infrastructure
{
    public interface IIncomeProductionStep<TStepModel, TCommand>
       : IProductStep<TStepModel, IIncomeProductionApplication, TCommand>
        , IOnErrorCallBackHolder<IIncomeProductionStep<TStepModel, TCommand>>
    {
    }
}

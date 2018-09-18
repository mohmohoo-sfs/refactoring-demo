namespace api.Interfaces
{
    public interface IProductStep<TStepModel, TApplication, TCommand>
        : ITemplateFactory<TStepModel, TCommand>
    {
        TApplication GetFullApplicationObject(TStepModel stepData);
    }
}

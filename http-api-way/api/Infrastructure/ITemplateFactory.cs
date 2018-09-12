namespace api.Infrastructure
{
    public interface ITemplateFactory<TStepModel, TCommand>
    {
        IStepProcessTemplate<TStepModel, TCommand> GetTemplate();
    }
}

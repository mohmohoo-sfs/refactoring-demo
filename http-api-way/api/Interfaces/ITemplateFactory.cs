namespace api.Interfaces
{
    public interface ITemplateFactory<TStepModel, TCommand>
    {
        IStepProcessTemplate<TStepModel, TCommand> GetTemplate();
    }
}

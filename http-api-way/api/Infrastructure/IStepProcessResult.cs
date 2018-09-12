namespace api.Infrastructure
{
    public interface IStepProcessResult
    {
        int Id { get; }

        int Version { get; }

        bool IsSuccess { get; }
    }
}

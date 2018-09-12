namespace api.Infrastructure
{
    public interface IError
    {
        string MemberName { get; }
        string Message { get; }
    }
}

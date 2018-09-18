namespace api.Interfaces
{
    public interface IError
    {
        string MemberName { get; }
        string Message { get; }
    }
}

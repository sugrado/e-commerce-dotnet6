namespace ECommerceBackend.Application.CorePackages.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}

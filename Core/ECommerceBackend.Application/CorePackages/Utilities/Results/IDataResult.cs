namespace ECommerceBackend.Application.CorePackages.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}

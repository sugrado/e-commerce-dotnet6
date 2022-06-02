namespace ECommerceBackend.Application.CorePackages.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string successMessage) : base(true, successMessage)
        {

        }

        public SuccessResult() : base(true)
        {

        }
    }
}

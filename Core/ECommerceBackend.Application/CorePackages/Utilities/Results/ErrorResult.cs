﻿namespace ECommerceBackend.Application.CorePackages.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string errorMessage) : base(false, errorMessage)
        {

        }

        public ErrorResult() : base(false)
        {

        }
    }
}

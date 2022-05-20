using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBackend.Application.CorePackages.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}

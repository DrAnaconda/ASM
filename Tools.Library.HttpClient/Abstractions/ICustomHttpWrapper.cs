using System.Collections.Generic;
using System.Threading.Tasks;
using Tools.Library.HttpClient.CustomClasses;

namespace Tools.Library.HttpClient.Abstractions
{
    public interface ICustomHttpWrapper
    {
        Task<TReturnType> MakeJsonPostRequestAsync<TReturnType, TRequestType>(
            TRequestType requestBody, string resourcePath);

        Task MakeJsonPutRequestAsync(byte[] requestBody, string fullConfiguredPath);
    }
}
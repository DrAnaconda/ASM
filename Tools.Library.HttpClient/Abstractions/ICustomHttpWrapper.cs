using System.Threading.Tasks;

namespace Tools.Library.HttpClient.Abstractions
{
    public interface ICustomHttpWrapper
    {
        Task<TReturnType> MakeJsonPostRequestAsync<TReturnType, TRequestType>(
            TRequestType requestBody, string resourcePath);

        Task MakeJsonPutRequestAsync(byte[] requestBody, string fullConfiguredPath);
    }
}
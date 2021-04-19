using System;

namespace Tools.Library.HttpClient.Exceptions
{
    public class HttpLevelException : Exception
    {
        public object responseObject { get; }

        public HttpLevelException(object responseObject)
        {
            this.responseObject = responseObject;
        }
    }
}
using System;

namespace Tools.Configuration.Parser.Exceptions
{
    public class PropertyNotFoundException : InvalidOperationException
    {
        public PropertyNotFoundException(string message)
        {
        }
    }
}
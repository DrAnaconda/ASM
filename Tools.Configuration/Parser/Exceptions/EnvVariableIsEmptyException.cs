using System;
using System.Runtime.Serialization;

namespace Tools.Configuration.Parser.Exceptions
{
    public class EnvVariableIsEmptyException : ArgumentNullException
    {
        public EnvVariableIsEmptyException(string? paramName) : base(paramName)
        {
        }
    }
}
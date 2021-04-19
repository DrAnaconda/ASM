using RestSharp;

namespace Tools.Library.HttpClient.CustomClasses
{
    public class Parameter
    {
        public ParameterType pType { get; }
        public string pName { get; }
        public string pVal { get; }

        public Parameter(ParameterType pType, string pName, string pVal)
        {
            this.pType = pType;
            this.pName = pName;
            this.pVal = pVal;
        }
    }
}
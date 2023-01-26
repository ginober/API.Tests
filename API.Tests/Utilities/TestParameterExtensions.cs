using NUnit.Framework;

namespace API.Tests.Utilities
{
    public static class TestParameterExtensions
    {
        public static IEnumerable<KeyValuePair< string,string>> ToKeyValuePairs(this TestParameters parameters)
        {



            return parameters.ToKeyValuePairs();
        }
    }
}

using System;

namespace FluentFixture.Extensions
{
    public static class ThenResultExtensions
    {
        public static void WithParameter(this IThenResult<ArgumentException> result, string paramName)
        {
            var ex = result.Result;
            if (paramName != null && ex.ParamName != paramName)
            {
                Test.Fail($"Param names are not equal: \"{ex.ParamName}\" != \"{paramName}\"");
            }
        }
    }
}
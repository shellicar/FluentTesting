using FluentFixture;
using Infrastructure;

namespace InfrastructureTests.Extensions
{
    public static class ResultTesterBuilderExtensions
    {
        public static ITestDefinition<ResultTester> Transform(this ITestDefinition<ResultTester> builder, string text)
        {
            return builder.Invoke(x => x.Transform(text));
        }
    }
}
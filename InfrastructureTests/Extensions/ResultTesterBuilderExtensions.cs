using Architecture;
using FluentFixture;

namespace ArchitectureTests.Extensions
{
    public static class ResultTesterBuilderExtensions
    {
        public static ITestDefinition<ResultTester> WhenTransform(this ITestDefinition<ResultTester> builder, string text)
        {
            return builder.When(x => x.Transform(text));
        }
    }
}
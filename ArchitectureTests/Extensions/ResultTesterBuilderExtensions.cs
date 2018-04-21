using Architecture;
using FluentFixture;

namespace ArchitectureTests.Extensions
{
    public static class ResultTesterBuilderExtensions
    {
        public static FixtureBuilder<ResultTester> WhenTransform(this FixtureBuilder<ResultTester> builder, string text)
        {
            return builder.When(x => x.Transform(text));
        }
    }
}
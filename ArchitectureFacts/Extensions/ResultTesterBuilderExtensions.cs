using Architecture;
using FluentFixture;

namespace ArchitectureFacts.Extensions
{
    public static class ResultTesterBuilderExtensions
    {
        public static FixtureBuilder<ResultTester> WhenTransform(this FixtureBuilder<ResultTester> builder, string text)
        {
            builder.When(x => x.Transform(text));
            return builder;
        }
    }
}
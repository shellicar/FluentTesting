using Architecture;
using FluentFixture;

namespace ArchitectureFacts.Extensions
{
    public static class ResultTesterExtensions
    {
        public static FixtureBuilder<ResultTester> WhenTransform(this FixtureBuilder<ResultTester> builder, string text)
        {
            builder.When(x => x.Transform(text));
            return builder;
        }
    }
}
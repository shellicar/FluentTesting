using FluentFixture;

namespace ArchitectureTests.Builders
{
    internal static class DefaultBuilder
    {
        public static FixtureBuilder<T> Create<T>()
        {
            return FixtureBuilder<T>.Create();
        }
    }
}
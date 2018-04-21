using FluentFixture;

namespace ArchitectureFacts.Builders
{
    internal static class DefaultBuilder
    {
        public static FixtureBuilder<T> Create<T>()
        {
            return FixtureBuilder<T>.Create();
        }
    }
}
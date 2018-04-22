namespace FluentFixture
{
    public static class DefaultBuilder
    {
        public static IFixtureBuilder<T> Create<T>()
        {
            return FixtureBuilder<T>.Create();
        }
    }
}
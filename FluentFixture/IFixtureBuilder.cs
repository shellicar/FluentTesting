using FluentFixture.Delegates;

namespace FluentFixture
{
    public interface IFixtureBuilder<TFixture>
    {
        IFixtureBuilder<TFixture> AddMethod(Modify<TFixture> action);
        TFixture Build();
        IFixtureBuilder<TFixture> SetArguments(params object[] args);

        ITestDefinition<TFixture> When();
    }
}
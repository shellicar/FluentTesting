using System;

namespace FluentFixture
{
    public interface IFixtureBuilder<TFixture> : IFixtureBuilder, ITestDefinition<TFixture>
    {
        IFixtureBuilder<TFixture> AddMethod(Modify<TFixture> action);
        TFixture Build();
        IFixtureBuilder<TFixture> SetArguments(params object[] args);
    }

    public interface IFixtureBuilder
    {
        Func<object> Execute();
    }
}
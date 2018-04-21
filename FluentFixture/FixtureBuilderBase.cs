using System;

namespace FluentFixture
{
    public abstract class FixtureBuilderBase
    {
        public abstract Func<object> Execute();
    }
}
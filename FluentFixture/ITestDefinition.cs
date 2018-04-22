using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFixture
{
    public interface ITestDefinition
    {
        Func<object> Execute();
    }

    public interface ITestDefinition<TFixture> : ITestDefinition
    {
        ITestDefinition<TFixture> When(Action<TFixture> action);
        ITestDefinition<TFixture> WhenWithResult(Action<TFixture, object> action);
        ITestDefinition<TFixture> WhenWithResult<TResult>(Func<TFixture, object, TResult> func);
        ITestDefinition<TFixture> When<TResult>(Func<TFixture, TResult> func);
    }
}

using System;

namespace FluentFixture
{
    public interface ITestDefinition
    {
        Func<object> Execute();
    }

    public interface ITestDefinition<out TFixture> : ITestDefinition
    {
        ITestDefinition<TFixture> Invoke(Action<TFixture> action);
        ITestDefinition<TFixture> InvokeWithResult(Action<TFixture, object> action);
        ITestDefinition<TFixture> InvokeWithResult<TResult>(Func<TFixture, object, TResult> func);
        ITestDefinition<TFixture> Invoke<TResult>(Func<TFixture, TResult> func);
    }
}

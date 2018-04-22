using System;
using FluentFixture.Delegates;

namespace FluentFixture
{
    public interface ITestDefinition
    {
        Func<object> Execute();
    }

    public interface ITestDefinition<out TFixture> : ITestDefinition
    {
        ITestDefinition<TFixture> Invoke(TestAction<TFixture> action);
        ITestDefinition<TFixture> InvokeWithResult(TestActionWithResult<TFixture> action);
        ITestDefinition<TFixture> Invoke<TResult>(TestFunction<TFixture, TResult> func);
        ITestDefinition<TFixture> InvokeWithResult<TResult>(TestFunctionWithResult<TFixture, TResult> func);
    }
}

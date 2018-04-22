using System;

namespace FluentFixture
{
    public interface ITestDefinition
    {
        Func<object> Execute();
    }


    public delegate void TestAction<in TFixture>(TFixture fixture);
    public delegate void TestActionWithResult<in TFixture>(TFixture fixture, object previousResult);
    public delegate TResult TestFunction<in TFixture, out TResult>(TFixture fixture);
    public delegate TResult TestFunctionWithResult<in TFixture, out TResult>(TFixture fixture, object previousResult);

    public interface ITestDefinition<out TFixture> : ITestDefinition
    {
        ITestDefinition<TFixture> Invoke(TestAction<TFixture> action);
        ITestDefinition<TFixture> InvokeWithResult(TestActionWithResult<TFixture> action);
        ITestDefinition<TFixture> InvokeWithResult<TResult>(TestFunctionWithResult<TFixture, TResult> func);
        ITestDefinition<TFixture> Invoke<TResult>(TestFunction<TFixture, TResult> func);
    }
}

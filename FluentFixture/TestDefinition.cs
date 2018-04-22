using System;
using System.Collections.Generic;
using System.Linq;
using FluentFixture.Exceptions;

namespace FluentFixture
{
    internal class TestDefinition<TFixture> : ITestDefinition<TFixture>
    {
        public TestDefinition(FixtureBuilder<TFixture> fixtureBuilder)
        {
            FixtureBuilder = fixtureBuilder;
        }

        // results of the invoked methods
        private List<InvokeResult> InvokeResults { get; } = new List<InvokeResult>();

        // methods to perform
        private List<Action<TFixture>> InvokeList { get; } = new List<Action<TFixture>>();

        public FixtureBuilder<TFixture> FixtureBuilder { get; }

        /// <summary>
        /// Adds an action to perform on the fixture.
        /// </summary>
        /// <param name="action">The action.</param>
        public ITestDefinition<TFixture> Invoke(TestAction<TFixture> action)
        {
            void Newaction(TFixture x)
            {
                action(x);
                InvokeResults.Add(new InvokeResult());
            }

            InvokeList.Add(Newaction);
            return this;
        }

        /// <summary>
        /// Adds an action to perform on the fixture.<br />
        /// This uses the result of the previous invocation.
        /// </summary>
        /// <param name="action">The action.</param>
        public ITestDefinition<TFixture> InvokeWithResult(TestActionWithResult<TFixture> action)
        {
            void Newaction(TFixture x)
            {
                action(x, GetLastResult());
                InvokeResults.Add(new InvokeResult());
            }

            InvokeList.Add(Newaction);
            return this;
        }

        /// <summary>
        /// Adds a function to perform on the fixture.<br />
        /// This uses the result of the previous invocation.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="func">The action.</param>
        public ITestDefinition<TFixture> InvokeWithResult<TResult>(TestFunctionWithResult<TFixture, TResult> func)
        {
            void Newaction(TFixture x)
            {
                var result = func(x, GetLastResult());
                InvokeResults.Add(new InvokeResultObject(result));
            }

            InvokeList.Add(Newaction);
            return this;
        }

        /// <summary>
        /// Adds a function to perform on the fixture.<br />
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="func">The function.</param>
        public ITestDefinition<TFixture> Invoke<TResult>(TestFunction<TFixture, TResult> func)
        {
            void Newaction(TFixture x)
            {
                var result = func(x);
                InvokeResults.Add(new InvokeResultObject(result));
            }

            InvokeList.Add(Newaction);
            return this;
        }

        /// <summary>
        /// Executes the invocations, returning a method that can be used to retrieve the last result.
        /// </summary>
        /// <returns>a method that either returns the result of the last invocation, or throws an exception if the method has a return type of void.</returns>
        public Func<object> Execute()
        {
            if (InvokeList.Count == 0)
            {
                throw new InvalidOperationException("No actions to execute.");
            }

            var obj = FixtureBuilder.Build();
            foreach (var w in InvokeList)
            {
                w(obj);
            }

            return GetLastResult;
        }

        /// <summary>
        /// Gets the result of the last invocation, or throws an exception.
        /// </summary>
        /// <returns></returns>
        private object GetLastResult()
        {
            return InvokeResults.Last().GetResult();
        }

        private class InvokeResult
        {
            /// <summary>
            /// Gets the result.
            /// </summary>
            /// <exception cref="NoResultFromActionException"></exception>
            public virtual object GetResult()
            {
                throw new NoResultFromActionException();
            }
        }

        private class InvokeResultObject : InvokeResult
        {
            private readonly object _result;

            public InvokeResultObject(object result)
            {
                _result = result;
            }

            /// <summary>
            /// Gets the result.
            /// </summary>
            /// <returns>the result.</returns>
            public override object GetResult()
            {
                return _result;
            }
        }
    }
}
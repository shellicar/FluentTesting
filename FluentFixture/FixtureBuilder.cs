using System;
using System.Collections.Generic;
using System.Linq;
using FluentFixture.Exceptions;

namespace FluentFixture
{
    /// <summary>
    /// Class that helps build fixtures, perform operations and assert results.
    /// </summary>
    /// <typeparam name="TFixture">The type of the fixture.</typeparam>
    /// <seealso cref="FixtureBuilderBase" />
    class FixtureBuilder<TFixture> : FixtureBuilderBase, IFixtureBuilder<TFixture>
    {
        // results of the invoked methods
        private List<InvokeResult> InvokeResults { get; } = new List<InvokeResult>();
        // methods to perform
        private List<Action<TFixture>> InvokeList { get; } = new List<Action<TFixture>>();
        // actions to perform to build the object
        private List<Modify<TFixture>> BuildActions { get; } = new List<Modify<TFixture>>();

        private List<object> ConstructorArgs { get; } = new List<object>();

        public static FixtureBuilder<TFixture> Create()
        {
            return new FixtureBuilder<TFixture>();
        }

        /// <summary>
        /// Adds a method to use to build the object.
        /// </summary>
        /// <param name="action">The action.</param>
        public IFixtureBuilder<TFixture> AddMethod(Modify<TFixture> action)
        {
            BuildActions.Add(action);
            return this;
        }

        /// <summary>
        /// Sets the constructor arguments for the object.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public IFixtureBuilder<TFixture> SetArguments(params object[] args)
        {
            ConstructorArgs.Clear();
            ConstructorArgs.AddRange(args);
            return this;
        }

        /// <summary>
        /// Adds an action to perform on the fixture.
        /// </summary>
        /// <param name="action">The action.</param>
        public ITestDefinition<TFixture> When(Action<TFixture> action)
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
        public ITestDefinition<TFixture> WhenWithResult(Action<TFixture, object> action)
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
        public ITestDefinition<TFixture> WhenWithResult<TResult>(Func<TFixture, object, TResult> func)
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
        public ITestDefinition<TFixture> When<TResult>(Func<TFixture, TResult> func)
        {
            void Newaction(TFixture x)
            {
                var result = func(x);
                InvokeResults.Add(new InvokeResultObject(result));
            }

            InvokeList.Add(Newaction);
            return this;
        }

        public static implicit operator TFixture(FixtureBuilder<TFixture> builder)
        {
            return builder.Build();
        }

        /// <summary>
        /// Builds the fixture with the previously specified operations.
        /// </summary>
        public TFixture Build()
        {
            var fixture = (TFixture)Activator.CreateInstance(typeof(TFixture), ConstructorArgs.ToArray());

            foreach (var a in BuildActions)
            {
                fixture = a(fixture);
            }

            return fixture;
        }

        /// <summary>
        /// Executes the invocations, returning a method that can be used to retrieve the last result.
        /// </summary>
        /// <returns>a method that either returns the result of the last invocation, or throws an exception if the method has a return type of void.</returns>
        public override Func<object> Execute()
        {
            if (InvokeList.Count == 0)
            {
                throw new InvalidOperationException("No actions to execute.");
            }

            var obj = Build();
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
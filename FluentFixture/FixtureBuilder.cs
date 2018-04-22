using System;
using System.Collections.Generic;
using FluentFixture.Delegates;

namespace FluentFixture
{
    /// <summary>
    /// Class that helps build fixtures, perform operations and assert results.
    /// </summary>
    /// <typeparam name="TFixture">The type of the fixture.</typeparam>
    /// <seealso cref="IFixtureBuilder{TFixture}" />
    internal class FixtureBuilder<TFixture> : IFixtureBuilder<TFixture>
    {
        // actions to perform to build the object
        private List<Modify<TFixture>> BuildActions { get; } = new List<Modify<TFixture>>();

        private List<object> ConstructorArgs { get; } = new List<object>();

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

        public ITestDefinition<TFixture> When()
        {
            return new TestDefinition<TFixture>(this);
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

        public static FixtureBuilder<TFixture> Create()
        {
            return new FixtureBuilder<TFixture>();
        }
    }
}
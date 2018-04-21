using System;
using System.Collections.Generic;

namespace FluentFixture
{
    class FixtureBuilder<TFixture> : IEntityBuilder<TFixture>
    {
        private List<Modify<TFixture>> Actions { get; } = new List<Modify<TFixture>>();
        public void AddMethod(Modify<TFixture> action)
        {
            Actions.Add(action);
        }

        private List<object> ConstructorArgs { get; } = new List<object>();

        public IEntityBuilder<TFixture> SetArguments(params object[] args)
        {
            ConstructorArgs.Clear();
            ConstructorArgs.AddRange(args);
            return this;
        }

        public TFixture Build()
        {

            var fixture = (TFixture)Activator.CreateInstance(typeof(TFixture), ConstructorArgs.ToArray());

            foreach (var a in Actions)
            {
                fixture = a(fixture);
            }

            return fixture;
        }
    }
}
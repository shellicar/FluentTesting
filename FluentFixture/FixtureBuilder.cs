using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentFixture
{
    public class FixtureBuilder<TFixture> :FixtureBuilderBase //: FixtureBuilder<TFixture>
    {
        private List<ActionResult> InvokeResults { get; } = new List<ActionResult>();
        private List<Action<TFixture>> InvokeList { get; } = new List<Action<TFixture>>();
        private List<Modify<TFixture>> BuildActions { get; } = new List<Modify<TFixture>>();

        private List<object> ConstructorArgs { get; } = new List<object>();

        public static FixtureBuilder<TFixture> Create()
        {
            return new FixtureBuilder<TFixture>();
        }

        public FixtureBuilder<TFixture> AddMethod(Modify<TFixture> action)
        {
            BuildActions.Add(action);
            return this;
        }

        public FixtureBuilder<TFixture> SetArguments(params object[] args)
        {
            ConstructorArgs.Clear();
            ConstructorArgs.AddRange(args);
            return this;
        }


        public FixtureBuilder<TFixture> When(Action<TFixture> action)
        {
            void Newaction(TFixture x)
            {
                action(x);
                InvokeResults.Add(new ActionResult());
            }

            InvokeList.Add(Newaction);
            InvokeResults.Add(new ActionResult());
            return this;
        }

        public FixtureBuilder<TFixture> When<TResult>(Func<TFixture, TResult> action)
        {
            void Newaction(TFixture x)
            {
                var result = action(x);
                InvokeResults.Add(new ActionResultObject(result));
            }

            InvokeList.Add(Newaction);
            return this;
        }

        public static implicit operator TFixture(FixtureBuilder<TFixture> builder)
        {
            return builder.Build();
        }

        public TFixture Build()
        {
            var fixture = (TFixture)Activator.CreateInstance(typeof(TFixture), ConstructorArgs.ToArray());

            foreach (var a in BuildActions)
            {
                fixture = a(fixture);
            }

            return fixture;
        }

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

        private object GetLastResult()
        {
            return InvokeResults.Last().GetResult();
        }

        private class ActionResult
        {
            public virtual object GetResult()
            {
                throw new InvalidOperationException("No result from action.");
            }
        }

        private class ActionResultObject : ActionResult
        {
            private readonly object _result;

            public ActionResultObject(object result)
            {
                _result = result;
            }

            public override object GetResult()
            {
                return _result;
            }
        }
    }
}
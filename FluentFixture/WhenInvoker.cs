using System;

namespace FluentFixture
{
    public class WhenInvoker : IWhenInvoker
    {
        private readonly Action _invokeMethod;

        public WhenInvoker(Action invokeMethod)
        {
            _invokeMethod = invokeMethod;
        }

        public void When()
        {
            _invokeMethod();
        }
    }

    public class WhenInvoker<TResult> : IWhenInvoker<TResult>
    {
        private readonly Func<TResult> _invokeMethod;

        public WhenInvoker(Func<TResult> invokeMethod)
        {
            _invokeMethod = invokeMethod;
        }

        public TResult When()
        {
            return _invokeMethod();
        }
    }
}
using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentFixture
{
    public static class WhenResultExtensions
    {
        public static void ThenIsTrue(this IWhenInvoker<bool> result)
        {
            Assert.IsTrue(result.When());
        }

        public static void ThenIsFalse(this IWhenInvoker<bool> result)
        {
            Assert.IsFalse(result.When());
        }

        public static void ThenSuccess(this IWhenInvoker result)
        {
            result.When();
        }

        public static void ThenExpectException<TException, TResult>(this IWhenInvoker<TResult> result) where TException : Exception
        {
            Action action = () => result.When();
            Assert.ThrowsException<TException>(action);
        }

        public static void ThenExpectArgumentException<TResult>(this IWhenInvoker<TResult> result, string paramName)
        {
            Action action = () => result.When();
            var ex = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual(paramName, ex.ParamName);
        }

        public static void ThenExpectArgumentException(this IWhenInvoker result, string paramName)
        {
            Action action = result.When;
            var ex = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual(paramName, ex.ParamName);
        }

        public static void ThenExpectException<TException>(this IWhenInvoker result) where TException : Exception
        {
            Action invoke = result.When;
            Assert.ThrowsException<TException>(invoke);
        }
    }
}

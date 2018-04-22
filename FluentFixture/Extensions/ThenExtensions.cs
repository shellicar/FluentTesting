using System;
using System.Security.Cryptography.X509Certificates;

namespace FluentFixture.Extensions
{
    public static class ThenExtensions
    {
        public static IThenResult<TException> ThenExpectException<TException>(this ITestDefinition result) where TException : Exception
        {
            void Invoke()
            {
                result.Execute();
            }

            var ex = Test.AssertThrows<TException>(Invoke);
            return MakeResult(ex);
        }

        public static IThenResult<bool> ThenIsTrue(this ITestDefinition result)
        {
            var obj = (bool)result.Execute()();
            Test.AssertTrue(obj);
            return MakeResult(obj);
        }

        private static ThenResult<TResult> MakeResult<TResult>(TResult obj)
        {
            return new ThenResult<TResult>(obj);
        }

        public static IThenResult<bool> ThenIsFalse(this ITestDefinition result)
        {
            var obj = (bool)result.Execute()();
            Test.AssertFalse(obj);
            return MakeResult(obj);
        }

        public static void ThenSuccess(this ITestDefinition result)
        {
            Test.AssertNoThrow(() => result.Execute());
        }

        public static IThenResult<object> ThenIs<TFixture>(this ITestDefinition<TFixture> result, object value)
        {
            var obj = result.Execute()();
            Test.AssertEqual(obj, value);
            return MakeResult(obj);
        }

        public static IThenResult<object> ThenIsNot<TFixture>(this ITestDefinition<TFixture> result, object value)
        {
            var obj = result.Execute()();
            Test.AssertNotEqual(obj, value);
            return MakeResult(obj);
        }
    }
}
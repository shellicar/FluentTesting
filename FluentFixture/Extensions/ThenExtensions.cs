using System;

namespace FluentFixture.Extensions
{
    public static class ThenExtensions
    {
        public static void ThenExpectArgumentException(this ITestDefinition result, string paramName = null)
        {
            void Invoke()
            {
                result.Execute();
            }

            var ex = Test.AssertThrows<ArgumentException>(Invoke);
            if (paramName != null && ex.ParamName != paramName)
            {
                Test.Fail($"Param names are not equal: \"{ex.ParamName}\" != \"{paramName}\"");
            }
        }

        public static void ThenExpectException<TException>(this ITestDefinition result) where TException : Exception
        {
            void Invoke()
            {
                result.Execute();
            }

            Test.AssertThrows<TException>(Invoke);
        }

        public static void ThenIsTrue(this ITestDefinition result)
        {
            var obj = (bool)result.Execute()();
            Test.AssertTrue(obj);
        }

        public static void ThenIsFalse(this ITestDefinition result)
        {
            var obj = (bool)result.Execute()();
            Test.AssertFalse(obj);
        }

        public static void ThenSuccess(this ITestDefinition result)
        {
            result.Execute();
        }

        public static void ThenIs<TFixture>(this ITestDefinition<TFixture> result, object value)
        {
            var obj = result.Execute()();
            Test.AssertEqual(obj, value);
        }

        public static void ThenIsNot<TFixture>(this ITestDefinition<TFixture> result, object value)
        {
            var obj = result.Execute()();
            Test.AssertNotEqual(obj, value);
        }
    }
}
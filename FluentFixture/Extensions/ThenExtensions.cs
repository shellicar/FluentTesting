using System;

namespace FluentFixture.Extensions
{
    public static class ThenExtensions
    {
        public static void ThenExpectArgumentException(this FixtureBuilderBase result, string paramName = null)
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

        public static void ThenExpectException<TException>(this FixtureBuilderBase result) where TException : Exception
        {
            void Invoke()
            {
                result.Execute();
            }

            Test.AssertThrows<TException>(Invoke);
        }

        public static void ThenIsTrue<TEntity>(this FixtureBuilder<TEntity> result)
        {
            var obj = (bool)result.Execute()();
            Test.AssertTrue(obj);
        }

        public static void ThenIsFalse<TEntity>(this FixtureBuilder<TEntity> result)
        {
            var obj = (bool)result.Execute()();
            Test.AssertFalse(obj);
        }

        public static void ThenSuccess<TEntity>(this FixtureBuilder<TEntity> result)
        {
            result.Execute();
        }

        public static object ThenIs<TEntity>(this FixtureBuilder<TEntity> result, object value)
        {
            var obj = result.Execute()();
            Test.AssertEqual(obj, value);
            return obj;
        }

        public static void ThenIsNot<TEntity>(this FixtureBuilder<TEntity> result, object value)
        {
            var obj = result.Execute()();
            Test.AssertNotEqual(obj, value);
        }
    }
}
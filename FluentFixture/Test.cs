using System;
using FluentFixture.Exceptions;

namespace FluentFixture
{
    internal static class Test
    {
        public static TException AssertThrows<TException>(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                if (ex is TException a)
                {
                    return a;
                }
            }

            Fail("Method did not throw exception.");
            throw new NotImplementedException();
        }

        public static void AssertTrue(bool value)
        {
            if (value != true)
            {
                Fail("Value is not true.");
            }
        }

        public static void AssertFalse(bool value)
        {
            if (value)
            {
                Fail("Value is not false.");
            }
        }

        public static void AssertEqual(object lhs, object rhs)
        {
            var equal = Equals(lhs, rhs);
            if (!equal)
            {
                Fail("Values are not equal");
            }
        }

        public static void AssertNotEqual(object lhs, object rhs)
        {
            var equal = Equals(lhs, rhs);
            if (equal)
            {
                Fail("Values are equal");
            }
        }

        public static void Fail(string message)
        {
            throw new TestFailedException($"Test failed: {message}");
        }

        public static void AssertNoThrow(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw new TestFailedException($"Expected no exception, but exception {ex.GetType().Name} was thrown.", ex);
            }
        }
    }
}
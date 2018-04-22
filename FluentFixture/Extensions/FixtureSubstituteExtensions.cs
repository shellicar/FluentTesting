using System;
using NSubstitute;

namespace FluentFixture.Extensions
{
    public static class FixtureSubstituteExtensions
    {
        public static void ThenReceived<TInterface>(this ITestDefinition result, TInterface theInterface, int count, Action<TInterface> theAction)
            where TInterface : class
        {
            result.Execute();

            theAction(theInterface.Received(count));
        }

        public static void ThenReceived<TInterface>(this ITestDefinition result, TInterface theInterface, Action<TInterface> theAction)
            where TInterface : class
        {
            result.Execute();

            theAction(theInterface.Received());
        }
    }
}
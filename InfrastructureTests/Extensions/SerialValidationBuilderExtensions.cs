using FluentFixture;
using Infrastructure;

namespace InfrastructureTests.Extensions
{
    public static class SerialValidationBuilderExtensions
    {
        public static ITestDefinition<SerialValidator> Validate(this ITestDefinition<SerialValidator> fixture, string serial)
        {
            return fixture.Invoke(x => x.Validate(serial));
        }

        public static ITestDefinition<SerialValidator> Validate(this ITestDefinition<SerialValidator> fixture, BookSerial serial)
        {
            return fixture.Invoke(x => x.Validate(serial));
        }
    }
}
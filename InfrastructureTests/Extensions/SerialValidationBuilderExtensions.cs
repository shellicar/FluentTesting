using Architecture;
using FluentFixture;

namespace ArchitectureTests.Extensions
{
    public static class SerialValidationBuilderExtensions
    {
        public static ITestDefinition<SerialValidator> WhenValidate(this ITestDefinition<SerialValidator> fixture, string serial)
        {
            return fixture.When(x => x.Validate(serial));
        }

        public static ITestDefinition<SerialValidator> WhenValidate(this ITestDefinition<SerialValidator> fixture, BookSerial serial)
        {
            return fixture.When(x => x.Validate(serial));
        }
    }
}
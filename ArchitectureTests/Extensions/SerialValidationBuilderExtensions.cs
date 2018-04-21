using Architecture;
using FluentFixture;

namespace ArchitectureTests.Extensions
{
    public static class SerialValidationBuilderExtensions
    {
        public static FixtureBuilder<SerialValidator> WhenValidate(this FixtureBuilder<SerialValidator> fixture, string serial)
        {
            return fixture.When(x => x.Validate(serial));
        }

        public static FixtureBuilder<SerialValidator> WhenValidate(this FixtureBuilder<SerialValidator> fixture, BookSerial serial)
        {
            return fixture.When(x => x.Validate(serial));
        }
    }
}
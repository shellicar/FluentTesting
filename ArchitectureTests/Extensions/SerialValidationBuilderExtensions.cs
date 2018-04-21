using Architecture;
using FluentFixture;

namespace ArchitectureTests.Extensions
{
    public static class SerialValidationBuilderExtensions
    {
        public static FixtureBuilder<SerialValidator> WhenValidate(this FixtureBuilder<SerialValidator> fixture, string serial)
        {
            fixture.When(x => x.Validate(serial));
            return fixture;
        }

        public static FixtureBuilder<SerialValidator> WhenValidate(this FixtureBuilder<SerialValidator> fixture, BookSerial serial)
        {
            fixture.When(x => x.Validate(serial));
            return fixture;
        }
    }
}
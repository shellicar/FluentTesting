using Architecture;
using FluentFixture;

namespace ArchitectureFacts.Tests
{
    public static class SerialValidationExtensions
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
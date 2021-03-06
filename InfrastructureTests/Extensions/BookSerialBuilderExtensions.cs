using FluentFixture;
using Infrastructure;

namespace InfrastructureTests.Extensions
{
    /// <summary>
    /// Extension methods to build BookSerial objects fluently.
    /// </summary>
    internal static class BookSerialBuilderExtensions
    {
        /// <summary>
        /// Builds a BookSerial with a given text group.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="group">The group.</param>
        /// <returns>the updated builder.</returns>
        public static IFixtureBuilder<BookSerial> WithGroup(this IFixtureBuilder<BookSerial> builder, string group)
        {
            builder.AddMethod(x =>
            {
                x.Add(group);
                return x;
            });
            return builder;
        }

        /// <summary>
        /// Builds a BookSerial with a value that is considered valid.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>the updated builder.</returns>
        public static IFixtureBuilder<BookSerial> Valid(this IFixtureBuilder<BookSerial> builder)
        {
            var validSerial = "123-12345-1234";

            builder.AddMethod(x => BookSerial.Parse(validSerial));
            return builder;
        }

        /// <summary>
        /// Builds a BookSerial with the specified group replaced with the new value.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="group">The group.</param>
        /// <param name="value">The value.</param>
        /// <returns>the updated builder.</returns>
        public static IFixtureBuilder<BookSerial> SetGroup(this IFixtureBuilder<BookSerial> builder, int group, string value)
        {
            builder.AddMethod(x =>
            {
                x.Edit(group, value);
                return x;
            });
            return builder;
        }
    }
}
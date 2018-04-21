using Architecture;
using Core;
using FluentFixture;

namespace ArchitectureFacts.Extensions
{
    /// <summary>
    /// Extension methods to build BookSerial objects fluently.
    /// </summary>
    static class BookSerialExtensions
    {
        /// <summary>
        /// Builds a BookSerial with a given text group.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="group">The group.</param>
        /// <returns>the updated builder.</returns>
        public static IEntityBuilder<BookSerial> WithGroup(this IEntityBuilder<BookSerial> builder, string group)
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
        public static IEntityBuilder<BookSerial> Valid(this IEntityBuilder<BookSerial> builder)
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
        public static IEntityBuilder<BookSerial> SetGroup(this IEntityBuilder<BookSerial> builder, int group, string value)
        {
            builder.AddMethod(x =>
            {
                x.Edit(group, value);
                return x;
            });
            return builder;
        }

        /// <summary>
        /// Whens the validate.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="validator">The validator.</param>
        /// <returns></returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for WhenValidate
        public static IWhenInvoker WhenValidate(this IEntityBuilder<BookSerial> builder, IBookSerialValidator validator)
        {
            var entity = builder.Build();
            void InvokeMethod() => validator.Validate(entity.ToString());
            return new WhenInvoker(InvokeMethod);
        }
    }
}
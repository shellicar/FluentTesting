using Core;
using FluentFixture;
using Models;

namespace ArchitectureTests.Extensions
{
    /// <summary>
    /// Extension methods to build Book objects fluently.
    /// </summary>
    internal static class BookBuilderExtensions
    {
        /// <summary>
        /// Creates a Book that is considred valid.<br />
        /// Validation on an object created this way should succeed.<br />
        /// If the logic is changed, then this must be updated, or it indicates a bug.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>a valid Book.</returns>
        public static IFixtureBuilder<Book> Valid(this IFixtureBuilder<Book> builder)
        {
            builder.AddMethod(x =>
            {
                x.Title = "valid_title";
                x.Serial = "123-12345-1234";
                return x;
            });
            return builder;
        }

        public static ITestDefinition<Book> WhenValidateModel(this ITestDefinition<Book> builder, string paramName)
        {
            return builder.When(x => x.ValidateModel(paramName));
        }
    }
}

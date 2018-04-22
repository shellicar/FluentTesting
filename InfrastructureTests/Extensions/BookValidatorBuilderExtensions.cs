using Architecture;
using FluentFixture;
using Models;

namespace ArchitectureTests.Extensions
{
    public static class BookValidatorBuilderExtensions
    {
        public static ITestDefinition<BookValidator> WhenValidate(this ITestDefinition<BookValidator> builder, Book book)
        {
            return builder.When(x => x.Validate(book));
        }
    }
}

using FluentFixture;
using Infrastructure;
using Models;

namespace InfrastructureTests.Extensions
{
    public static class BookValidatorBuilderExtensions
    {
        public static ITestDefinition<BookValidator> Validate(this ITestDefinition<BookValidator> builder, Book book)
        {
            return builder.Invoke(x => x.Validate(book));
        }
    }
}

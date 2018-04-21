using Architecture;
using FluentFixture;
using Models;

namespace ArchitectureFacts.Extensions
{
    public static class BookValidatorExtensions
    {
        public static FixtureBuilder<BookValidator> WhenValidate(this FixtureBuilder<BookValidator> builder, Book book)
        {
            return builder.When(x => x.Validate(book));
        }
    }
}

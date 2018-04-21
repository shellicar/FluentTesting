using Core;
using Models;

namespace Architecture
{
    /// <summary>
    /// Class to validate that a book passses validation.
    /// </summary>
    /// <seealso cref="IBookValidator" />
    public class BookValidator : IBookValidator
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="serialValidator">The serial validator.</param>
        public BookValidator(IBookSerialValidator serialValidator)
        {
            SerialValidator = serialValidator;
        }

        private IBookSerialValidator SerialValidator { get; }

        /// <summary>
        /// Validates the specified book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        public void Validate(Book book)
        {
            book.Validate(nameof(book));

            SerialValidator.Validate(book.Serial);
        }
    }
}

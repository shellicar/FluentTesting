using System;
using Architecture;
using ArchitectureFacts.Builders;
using ArchitectureFacts.Extensions;
using Core;
using FluentFixture;
using FluentFixture.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using NSubstitute;

namespace ArchitectureFacts.Tests
{
    [TestClass]
    public class BookValidatorFacts
    {
        private readonly FixtureBuilder<BookValidator> _sut;

        public BookValidatorFacts()
        {
            _sut = DefaultBuilder.Create<BookValidator>()
                .SetArguments(Substitute.For<IBookSerialValidator>());
        }

        [TestMethod]
        public void Book_cannot_be_null()
        {
            _sut.WhenValidate(null)

                .ThenExpectException<ArgumentNullException>();
        }

        [TestMethod]
        public void Book_title_cannot_be_null()
        {
            var bookWithoutTitle = DefaultBuilder.Create<Book>()
                .Valid()
                .With(x => x.Title = null);

            _sut.WhenValidate(bookWithoutTitle)

                .ThenExpectArgumentException(nameof(Book.Title));
        }

        [TestMethod]
        public void Book_requires_title_and_serial()
        {
            var bookWithoutTitle = DefaultBuilder.Create<Book>();

            _sut.WhenValidate(bookWithoutTitle)

                .ThenExpectArgumentException();
        }

        [TestMethod]
        public void Can_validate_valid_book()
        {
            var book = DefaultBuilder.Create<Book>()
                .Valid();

            _sut.WhenValidate(book)

                .ThenSuccess();
        }
    }
}
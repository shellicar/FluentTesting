using System;
using Architecture;
using ArchitectureTests.Extensions;
using Core;
using FluentFixture;
using FluentFixture.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using NSubstitute;

namespace ArchitectureTests.Tests
{
    [TestClass]
    public class BookValidatorFacts
    {
        private readonly IFixtureBuilder<BookValidator> _sut;

        public BookValidatorFacts()
        {
            _sut = DefaultBuilder.Create<BookValidator>()
                .SetArguments(BookSerialValidator);
        }

        private IBookSerialValidator BookSerialValidator { get; } = Substitute.For<IBookSerialValidator>();

        [TestMethod]
        public void Calls_book_serial_validator_validate_method()
        {
            Book book = DefaultBuilder.Create<Book>()
                .Valid()
                .Build();

            _sut.WhenValidate(book)

                .ThenReceived(BookSerialValidator, x => x.Validate(book.Serial));
        }

        [TestMethod]
        public void Doesnt_stop_exception_from_validate()
        {
            BookSerialValidator.When(x => x.Validate(Arg.Any<string>())).Throw<TestingException>();

            Book book = DefaultBuilder.Create<Book>()
                .Valid()
                .Build();

            _sut.WhenValidate(book)

                .ThenExpectException<TestingException>();

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
                .With(x => x.Title = null)
                .Build();

            _sut.WhenValidate(bookWithoutTitle)

                .ThenExpectArgumentException(nameof(Book.Title));
        }

        [TestMethod]
        public void Book_requires_title_and_serial()
        {
            var bookWithoutTitle = DefaultBuilder.Create<Book>()
                .Build();

            _sut.WhenValidate(bookWithoutTitle)

                .ThenExpectArgumentException();
        }

        [TestMethod]
        public void Can_validate_valid_book()
        {
            var book = DefaultBuilder.Create<Book>()
                .Valid()
                .Build();

            _sut.WhenValidate(book)

                .ThenSuccess();
        }

        private class TestingException : Exception
        { }
    }
}
using System;
using Architecture;
using ArchitectureFacts.Extensions;
using Core;
using FluentFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using NSubstitute;

namespace ArchitectureFacts.Tests
{
    [TestClass]
    public class BookValidatorFacts : FixtureBase
    {
        protected IEntityBuilder<BookValidator> CreateValidator()
        {
            return Create<BookValidator>()
                .SetArguments(Substitute.For<IBookSerialValidator>());
        }

        [TestMethod]
        public void Book_cannot_be_null()
        {
            CreateValidator()

                .WhenValidate(null)

                .ThenExpectException<ArgumentNullException>();
        }

        [TestMethod]
        public void Book_title_cannot_be_null()
        {
            var bookWithoutTitle = Create<Book>().Valid()
                .With(x => x.Title = null)
                .Build();

            CreateValidator()

                .WhenValidate(bookWithoutTitle)

                .ThenExpectArgumentException(nameof(Book.Title));
        }

        [TestMethod]
        public void Book_requires_title_and_serial()
        {
            var bookWithoutTitle = Create<Book>()
                .With(x =>
                {
                    x.Title = null;
                    x.Serial = null;
                })
                .Build();

            CreateValidator()

                .WhenValidate(bookWithoutTitle)

                .ThenExpectArgumentException("book");
        }

        [TestMethod]
        public void Can_validate_valid_book()
        {
            var book = Create<Book>().Valid().Build();

            CreateValidator()

                .WhenValidate(book)

                .ThenSuccess();
        }
    }
}
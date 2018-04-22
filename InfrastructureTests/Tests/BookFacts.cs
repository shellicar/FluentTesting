using FluentFixture;
using FluentFixture.Extensions;
using InfrastructureTests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace InfrastructureTests.Tests
{
    [TestClass]
    public class BookFacts
    {
        [TestMethod]
        public void Book_class_exists()
        {
            // tdd artefact...
            new Book();
        }

        [TestMethod]
        public void Can_build_book()
        {
            var book = DefaultBuilder.Create<Book>()
                .Build();

            Assert.IsInstanceOfType(book, typeof(Book));
        }

        [TestMethod]
        public void Can_build_valid_book()
        {
            var book = DefaultBuilder.Create<Book>()
                .Valid()
                .Build();

            Assert.IsInstanceOfType(book, typeof(Book));
        }

        [TestMethod]
        public void Valid_book_is_valid()
        {
            DefaultBuilder.Create<Book>()
                .Valid()

                .When()
                .PerformValidateModel("book")

                .ThenSuccess();
        }

        [TestMethod]
        public void Default_book_isnt_valid()
        {
            DefaultBuilder.Create<Book>()

                .When()
                .PerformValidateModel("book")

                .ThenExpectArgumentException("book");
        }
    }
}
using ArchitectureTests.Builders;
using ArchitectureTests.Extensions;
using Core;
using FluentFixture.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace ArchitectureTests.Tests
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
            Book book = DefaultBuilder.Create<Book>();

            Assert.IsInstanceOfType(book, typeof(Book));
        }

        [TestMethod]
        public void Can_build_valid_book()
        {
            Book book = DefaultBuilder.Create<Book>()
                .Valid();

            Assert.IsInstanceOfType(book, typeof(Book));
        }

        [TestMethod]
        public void Valid_book_is_valid()
        {
            DefaultBuilder.Create<Book>()
                .Valid()

                .WhenValidateModel("book")

                .ThenSuccess();
        }

        [TestMethod]
        public void Default_book_isnt_valid()
        {
            DefaultBuilder.Create<Book>()

                .WhenValidateModel("book")

                .ThenExpectArgumentException("book");
        }
    }
}
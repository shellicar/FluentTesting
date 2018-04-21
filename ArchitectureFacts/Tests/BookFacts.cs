using ArchitectureFacts.Extensions;
using Core;
using FluentFixture;
using FluentFixture.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace ArchitectureFacts.Tests
{
    [TestClass]
    public class BookFacts : FixtureBase
    {
        [TestMethod]
        public void Book_class_exists()
        {
            new Book();
        }

        [TestMethod]
        public void Can_build_book()
        {
            Book book = Create<Book>();

            Assert.IsInstanceOfType(book, typeof(Book));
        }

        [TestMethod]
        public void Can_build_valid_book()
        {
            Book book = Create<Book>().Valid();


            Assert.IsInstanceOfType(book, typeof(Book));
        }

        [TestMethod]
        public void Valid_book_is_valid()
        {
            Create<Book>()
                .Valid()

                .When(x => x.Validate("book"))

                .ThenSuccess();
        }

        [TestMethod]
        public void Default_book_isnt_valid()
        {
            Create<Book>()

                .When(x => x.Validate("book"))

                .ThenExpectArgumentException("book");
        }
    }
}
using ArchitectureFacts.Extensions;
using FluentFixture;
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
            var book = Create<Book>().Build();
            Assert.IsNotNull(book);
        }

        [TestMethod]
        public void Can_build_valid_book()
        {
            var book = Create<Book>().Valid().Build();
            Assert.IsNotNull(book);
        }
    }
}
using Architecture;
using ArchitectureFacts.Builders;
using ArchitectureFacts.Extensions;
using FluentFixture;
using FluentFixture.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArchitectureFacts.Tests
{
    [TestClass]
    public class ResultTesterFacts
    {
        private readonly FixtureBuilder<ResultTester> _sut;

        public ResultTesterFacts()
        {
            _sut = DefaultBuilder.Create<ResultTester>();
        }

        [TestMethod]
        public void Transformed_string_is_reversed()
        {
            var text = "hello";

            _sut.WhenTransform(text)

                .ThenIs("olleh");
        }

        [TestMethod]
        public void Transformed_string_is_not_original_value()
        {
            var text = "hello";

            _sut.WhenTransform(text)

                .ThenIsNot("hello");
        }
    }
}

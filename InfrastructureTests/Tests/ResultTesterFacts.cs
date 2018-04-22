using FluentFixture;
using FluentFixture.Extensions;
using Infrastructure;
using InfrastructureTests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfrastructureTests.Tests
{
    [TestClass]
    public class ResultTesterFacts
    {
        private readonly IFixtureBuilder<ResultTester> _sut;

        public ResultTesterFacts()
        {
            _sut = DefaultBuilder.Create<ResultTester>();
        }

        [TestMethod]
        public void Transformed_string_is_reversed()
        {
            var text = "hello";

            _sut.When()
                .Transform(text)

                .ThenIs("olleh");
        }

        [TestMethod]
        public void Transformed_string_is_not_original_value()
        {
            var text = "hello";

            _sut.When()
                .Transform(text)

                .ThenIsNot("hello");
        }
    }
}

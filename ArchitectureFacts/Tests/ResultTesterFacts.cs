using Architecture;
using ArchitectureFacts.Extensions;
using FluentFixture;
using FluentFixture.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace ArchitectureFacts.Tests
{
    [TestClass]
    public class ResultTesterFacts : FixtureBase
    {
        [TestMethod]
        public void Transformed_string_is_reversed()
        {
            var text = "hello";

            Create<ResultTester>()

                .WhenTransform(text)

                .ThenIs("olleh");
        }

        [TestMethod]
        public void Transformed_string_is_not_original_value()
        {
            var text = "hello";

            Create<ResultTester>()

                .WhenTransform(text)

                .ThenIsNot("hello");
        }
    }
}

using Architecture;
using ArchitectureFacts.Builders;
using ArchitectureFacts.Extensions;
using FluentFixture.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArchitectureFacts.Tests
{
    [TestClass]
    public class ResultTesterFacts
    {
        [TestMethod]
        public void Transformed_string_is_reversed()
        {
            var text = "hello";

            DefaultBuilder.Create<ResultTester>()

                .WhenTransform(text)

                .ThenIs("olleh");
        }

        [TestMethod]
        public void Transformed_string_is_not_original_value()
        {
            var text = "hello";

            DefaultBuilder.Create<ResultTester>()

                .WhenTransform(text)

                .ThenIsNot("hello");
        }
    }
}

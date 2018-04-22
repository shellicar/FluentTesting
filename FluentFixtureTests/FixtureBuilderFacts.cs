using FluentFixture;
using FluentFixture.Exceptions;
using FluentFixture.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentFixtureTests
{
    [TestClass]
    public class FixtureBuilderFacts
    {
        [TestMethod]
        public void Checking_result_from_action_raises_error()
        {
            void DoAction(TestingClass x)
            {

            }

            Assert.ThrowsException<NoResultFromActionException>(() =>
            {
                new TestingClass();
                DefaultBuilder.Create<TestingClass>()

                    .When(DoAction)

                    .ThenIs(true);
            });
        }

        [TestMethod]
        public void Checking_result_from_func_returns_result()
        {
            int DoAction(TestingClass x)
            {
                return 5000;
            }

            var result = DefaultBuilder.Create<TestingClass>()

                .When(DoAction)

                .ThenIs(5000);

            Assert.AreEqual(5000, result);
        }
    }
}
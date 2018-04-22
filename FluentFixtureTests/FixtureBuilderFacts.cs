using System;
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
            var test = DefaultBuilder.Create<TestingClass>()
                .When()
                .Invoke(x => { });

            void When()
            {
                test.ThenIs(true);
            }

            Assert.ThrowsException<NoResultFromActionException>((Action) When);
        }

        [TestMethod]
        public void Can_assert_result()
        {
            DefaultBuilder.Create<TestingClass>()
                .When()
                .Invoke(x => 5000)

                .ThenIs(5000);
        }

        [TestMethod]
        public void Asserting_incorrect_result_raises_Exception()
        {
            var test = DefaultBuilder.Create<TestingClass>()
                .When()
                .Invoke(x => 4999);

            void When()
            {
                test.ThenIs(5000);
            }

            Assert.ThrowsException<TestFailedException>((Action) When);
        }
    }
}
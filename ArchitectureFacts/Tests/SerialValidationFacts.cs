using System;
using Architecture;
using Architecture.Exceptions;
using ArchitectureFacts.Extensions;
using FluentFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArchitectureFacts.Tests
{
    [TestClass]
    public class SerialValidationFacts : FixtureBase
    {
        public SerialValidationFacts()
        {
            sut = new SerialValidator();
        }

        private readonly SerialValidator sut;

        [TestMethod]
        public void Serial_cannot_be_null()
        {
            string serial = null;

            void When() => sut.Validate(serial);

            Assert.ThrowsException<ArgumentNullException>((Action)When);
        }

        [TestMethod]
        public void Serial_cannot_be_empty()
        {
            string serial = "    ";

            void When() => sut.Validate(serial);

            Assert.ThrowsException<ArgumentException>((Action)When);
        }

        [TestMethod]
        public void Valid_serial_is_valid()
        {
            Create<BookSerial>().Valid()

                .WhenValidate(sut)

                .ThenSuccess();
        }

        [TestMethod]
        public void Serial_must_have_three_groups()
        {
            Create<BookSerial>()
                .WithGroup("123")
                .WithGroup("123")

                .WhenValidate(sut)

                .ThenExpectException<GroupCountException>();
        }

        [TestMethod]
        public void First_group_must_be_3_characters_long()
        {
            Create<BookSerial>().Valid()
                .SetGroup(0, "12")

                .WhenValidate(sut)

                .ThenExpectException<GroupParseException>();
        }
    }
}

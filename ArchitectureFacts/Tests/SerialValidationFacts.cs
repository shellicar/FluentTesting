using System;
using Architecture;
using Architecture.Exceptions;
using ArchitectureFacts.Builders;
using ArchitectureFacts.Extensions;
using FluentFixture;
using FluentFixture.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArchitectureFacts.Tests
{
    [TestClass]
    public class SerialValidationFacts
    {
        private readonly FixtureBuilder<SerialValidator> _sut;

        public SerialValidationFacts()
        {
            _sut = new FixtureBuilder<SerialValidator>();
        }

        [TestMethod]
        public void Serial_cannot_be_null()
        {
            string serial = null;

            _sut.WhenValidate(serial)

                .ThenExpectException<ArgumentNullException>();
        }

        [TestMethod]
        public void Serial_cannot_be_empty()
        {
            var serial = "    ";

            _sut.WhenValidate(serial)

                .ThenExpectException<ArgumentException>();
        }

        [TestMethod]
        public void Valid_serial_is_valid()
        {
            var serial = DefaultBuilder.Create<BookSerial>().Valid();

            _sut.WhenValidate(serial)

            .ThenSuccess();
        }

        [TestMethod]
        public void Serial_must_have_three_groups()
        {
            var serial = DefaultBuilder.Create<BookSerial>()
                .WithGroup("123")
                .WithGroup("123");

            _sut.WhenValidate(serial)

            .ThenExpectException<GroupCountException>();
        }

        [TestMethod]
        public void First_group_must_be_3_characters_long()
        {
            var serial = DefaultBuilder.Create<BookSerial>().Valid()
                .SetGroup(0, "12");

            _sut.WhenValidate(serial)

            .ThenExpectException<GroupParseException>();
        }
    }
}

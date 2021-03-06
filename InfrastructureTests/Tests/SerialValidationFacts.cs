﻿using System;
using FluentFixture;
using FluentFixture.Extensions;
using Infrastructure;
using Infrastructure.Exceptions;
using InfrastructureTests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfrastructureTests.Tests
{
    [TestClass]
    public class SerialValidationFacts
    {
        private readonly IFixtureBuilder<SerialValidator> _sut;

        public SerialValidationFacts()
        {
            _sut = DefaultBuilder.Create<SerialValidator>();
        }

        [TestMethod]
        public void Serial_cannot_be_null()
        {
            const string serial = null;

            _sut.When()
                .Validate(serial)

                .ThenExpectException<ArgumentNullException>();
        }

        [TestMethod]
        public void Serial_cannot_be_empty()
        {
            var serial = "    ";

            _sut.When().
                Validate(serial)

                .ThenExpectException<ArgumentException>();
        }

        [TestMethod]
        public void Valid_serial_is_valid()
        {
            var serial = DefaultBuilder.Create<BookSerial>()
                .Valid()
                .Build();

            _sut.When()
                .Validate(serial)

                .ThenSuccess();
        }

        [TestMethod]
        public void Serial_must_have_three_groups()
        {
            var serial = DefaultBuilder.Create<BookSerial>()
                .WithGroup("123")
                .WithGroup("123")
                .Build();

            _sut.When()
                .Validate(serial)

                .ThenExpectException<GroupCountException>();
        }

        [TestMethod]
        public void First_group_must_be_3_characters_long()
        {
            var serial = DefaultBuilder.Create<BookSerial>()
                .Valid()
                .SetGroup(0, "12")
                .Build();

            _sut.When()
                .Validate(serial)

                .ThenExpectException<GroupParseException>();
        }
    }
}

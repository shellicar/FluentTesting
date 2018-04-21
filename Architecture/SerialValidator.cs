using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Architecture.Exceptions;
using Core;

namespace Architecture
{
    /// <summary>
    /// Performs validation on a string to assert that it is considered a valid serial.
    /// </summary>
    /// <seealso cref="Core.IBookSerialValidator" />
    public class SerialValidator : IBookSerialValidator
    {
        /// <summary>
        /// Validates the specified serial.<br />
        /// Splits the string into groups based on the separator.<br />
        /// Expects 3 groups to be the following length: 3, 5, 4.
        /// </summary>
        /// <param name="serial">The serial.</param>
        /// <exception cref="ArgumentNullException">serial</exception>
        /// <exception cref="ArgumentException">serial</exception>
        /// <exception cref="GroupCountException"></exception>
        /// <exception cref="GroupParseException"></exception>
        public void Validate(string serial)
        {
            if (serial is null)
            {
                throw new ArgumentNullException(nameof(serial));
            }
            if (string.IsNullOrWhiteSpace(serial))
            {
                throw new ArgumentException(nameof(serial));
            }

            var split = serial.Split(BookSerial.Separator);
            if (split.Length != 3)
            {
                throw new GroupCountException("Expected 3 groups");
            }

            if (split[0].Length != 3)
            {
                throw new GroupParseException("Group 1.");
            }
            if (split[1].Length != 5)
            {
                throw new GroupParseException("Group 2.");
            }
            if (split[2].Length != 4)
            {
                throw new GroupParseException("Group 3.");
            }

            if (split.SelectMany(x => x).Any(x => !char.IsDigit(x)))
            {
                throw new GroupParseException("Groups must contain only digits.");
            }
        }
    }
}

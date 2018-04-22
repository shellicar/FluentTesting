using System;
using System.Collections.Generic;
using System.Linq;

namespace Architecture
{
    /// <summary>
    /// Book serial class to encapsulate book serial text and provide simple methods to edit, add or parse text.<br />
    /// This does not perform validation, only that the text is split into groups by a delimiter.
    /// </summary>
    public class BookSerial
    {
        public const char Separator = '-';

        /// <summary>
        /// Default constructor for testing.
        /// </summary>
        public BookSerial()
        {
            Groups = new List<string>();
        }

        protected BookSerial(IEnumerable<string> groups)
        {
            Groups = groups.ToList();
        }

        private List<string> Groups { get; }

        /// <summary>
        /// Add a group of characters to the serial.
        /// </summary>
        /// <param name="group">The group.</param>
        public void Add(string group)
        {
            Groups.Add(group);
        }

        /// <summary>
        /// Replace a group with the specified text.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        public void Edit(int index, string value)
        {
            Groups[index] = value;
        }

        /// <summary>
        /// Parses the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>a new BookSerial.</returns>
        /// <exception cref="ArgumentNullException">text</exception>
        public static BookSerial Parse(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text), "Text must not be null, empty, or contain only whitespace.");
            }

            var groups = text.Split(Separator);
            return new BookSerial(groups);
        }

        public override string ToString()
        {
            return string.Join(Separator.ToString(), Groups);
        }
    }
}

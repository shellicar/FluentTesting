using System;
using System.Collections.Generic;
using System.Text;
using Architecture;
using FluentFixture;
using Models;

namespace ArchitectureFacts.Extensions
{
    public static class BookValidatorExtensions
    {
        public static IWhenInvoker WhenValidate(this IEntityBuilder<BookValidator> builder, Book book)
        {
            var validator = builder.Build();
            Action action = () => validator.Validate(book);
            return new WhenInvoker(action);
        }
    }
}

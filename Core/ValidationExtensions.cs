using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Core
{
    public static class ValidationExtensions
    {
        public static void ValidateModel<TModel>(this TModel model, string paramName)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(model, context, results))
            {
                var exceptions = results.Select(CreateException).ToList();
                if (exceptions.Count == 1)
                {
                    throw exceptions.First();
                }

                var aggregate = new AggregateException(exceptions);
                var message = string.Join(Environment.NewLine, results.Select(x => x.ErrorMessage));
                throw new ArgumentException(message, paramName, aggregate);

            }
        }

        private static ArgumentException CreateException(ValidationResult arg)
        {
            return new ArgumentException(arg.ErrorMessage, arg.MemberNames.FirstOrDefault());
        }
    }
}

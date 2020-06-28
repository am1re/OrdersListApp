using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Application.Common.Exceptions
{
    public class AppValidationException : Exception
    {
        public Dictionary<string, string[]> Failures { get; }

        public AppValidationException() : base("One or more validation failures have occurred.")
        {
        }

        public AppValidationException(Dictionary<string, string[]> failures) : this()
        {
            Failures = failures;
        }

        public AppValidationException(IList<ValidationFailure> failures) : this()
        {
            Failures = new Dictionary<string, string[]>();
            
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }
    }
}
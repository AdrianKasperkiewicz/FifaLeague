using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.TeamAggregate
{
    public class EmailAddress : ValueObject
    {
        public EmailAddress(string email)
        {
            this.ValidateAndThrow(email);

            this.Value = email;
        }

        public string Value { get; }

        public static bool IsCorrectEmail(string email)
        {
            return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(email);
        }

        public void ValidateAndThrow(string email)
        {
            if (!IsCorrectEmail(email))
            {
                throw new FormatException("email is not valid.");
            }
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.Value;
        }
    }
}
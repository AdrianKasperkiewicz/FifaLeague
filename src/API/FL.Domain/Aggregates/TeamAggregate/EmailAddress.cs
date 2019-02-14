using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.TeamAggregate
{
    public class EmailAddress : ValueObject
    {
        private const string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public EmailAddress(string email)
        {
            Validate(email);

            this.Value = email;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.Value;
        }

        private static void Validate(string email)
        {
            if (!new Regex(EmailRegex).IsMatch(email))
            {
                throw new FormatException("email is not valid.");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

using FluentValidation.Results;

namespace FL.API.Application.BaseObjects
{
    public class CommandValidationException : Exception
    {
        public CommandValidationException(List<ValidationFailure> errors) 
            : base(PrapereMessage(errors) )
        {
        }

        private static string PrapereMessage(List<ValidationFailure> errors)
        {
            return string.Join(" ", errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
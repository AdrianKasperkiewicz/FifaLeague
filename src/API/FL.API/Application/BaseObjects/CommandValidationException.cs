﻿using System;
using System.Collections.Generic;
using System.Linq;

using FluentValidation.Results;

namespace FL.API.Application.BaseObjects
{
    public class CommandValidationException : Exception
    {
        public CommandValidationException(IEnumerable<ValidationFailure> errors) 
            : base(PrepareMessage(errors) )
        {
        }

        private static string PrepareMessage(IEnumerable<ValidationFailure> errors)
        {
            return string.Join(" ", errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
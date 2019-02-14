﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FL.API.Application.BaseObjects;
using FluentValidation;
using MediatR;

namespace FL.API.Application.Behaviors
{
    public class CommandValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public CommandValidationBehevior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);
            var errors = this.validators.Select(x => x.Validate(context)).SelectMany(result => result.Errors).Where(x => x != null).ToList();

            if (errors.Any())
            {
                throw new CommandValidationException(errors);
            }

            return next();
        }
    }
}

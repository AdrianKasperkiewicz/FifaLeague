using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FL.API.Infrastructure
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                var code = HttpStatusCode.BadRequest;

                var result = JsonConvert.SerializeObject(new { error = ex.Message });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;
                await context.Response.WriteAsync(result);
            }
        }
    }
}
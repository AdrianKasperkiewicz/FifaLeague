using System;
using System.Net;
using System.Threading.Tasks;

using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FL.API.Infrastructure
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (ValidationException ex)
            {
                var result = JsonConvert.SerializeObject(new { message = "Validation error occured: " + ex.Message });
                await CreateResponse(context, result);
            }
            catch (Exception ex)
            {
                var result = JsonConvert.SerializeObject(new { message = "Application occured: " + ex.Message });
                await CreateResponse(context, result);
            }
        }

        private static async Task CreateResponse(HttpContext context, string result)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(result);
        }
    }

    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
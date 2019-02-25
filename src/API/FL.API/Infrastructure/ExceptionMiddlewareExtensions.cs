using System.Net;
using System.Threading.Tasks;

using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FL.API.Infrastructure
{
    public class ExceptionMiddlewareExtensions
    {
        private readonly RequestDelegate next;

        public ExceptionMiddlewareExtensions(RequestDelegate next)
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
                var code = HttpStatusCode.BadRequest;

                var result = JsonConvert.SerializeObject(new { error = ex.Message });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;
                await context.Response.WriteAsync(result);
            }
        }
    }
}
using Microsoft.AspNetCore.Builder;

namespace FL.API.Infrastructure
{
    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();

        }
    }
}
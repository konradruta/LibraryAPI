using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace LibraryAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception login)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(login.Message);
            }
        }
    }
}

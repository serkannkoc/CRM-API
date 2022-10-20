using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Company2.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string message = "";
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            //context.Request.Headers.TryGetValue("id", out var id);
            //if (!id.ToString().Equals(context.User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault()?.Value))
            //{
            //    context.Response.ContentType = "application/json";
            //    var response = new ExceptionResponse("Gönderilen id ile tokendaki id aynı değil", 401);
            //    var json = JsonConvert.SerializeObject(response);
            //    await context.Response.WriteAsync(json);
            //}
            if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                context.Response.ContentType = "application/json";
                var response = new ExceptionResponse("Token Validation Has Failed. Request Access Denied",401);
                var json = JsonConvert.SerializeObject(response);
                await context.Response.WriteAsync(json);
                
            }
            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";
                var response = new ExceptionResponse(message);
                var json = JsonConvert.SerializeObject(response);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(json);
            }
        }
    }

    // Extension method ile IApplicationBuilder altına custom methodumuzu eklenmesini sağlıyoruz.
    public static class ErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorWrappingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorMiddleware>();
        }
    }
}

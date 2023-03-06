using EmployeeVacations.Api.Error;
using System.Net;
using System.Text.Json;

namespace EmployeeVacations.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment env) 
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) 
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, ex.Message, "Internal Server Error");

                var json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json);

            }
        }


    }
}

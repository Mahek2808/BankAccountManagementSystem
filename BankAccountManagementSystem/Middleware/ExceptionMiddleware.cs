using BankAccountManagementSystem.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BankAccountManagementSystem.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string jsonErrorResult = string.Empty;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            if (exception != null)
            {
                var errorModel = new Error(StatusCodes.Status500InternalServerError, $"{exception.Message}\n{exception.StackTrace}");
                jsonErrorResult = JsonConvert.SerializeObject(new ErrorResult(errorModel), new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
            }
            return context.Response.WriteAsync(jsonErrorResult);
        }
    }
}

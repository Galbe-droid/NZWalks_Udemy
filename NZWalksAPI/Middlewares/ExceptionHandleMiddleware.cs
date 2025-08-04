using System.Net;

namespace NZWalksAPI.Middlewares
{
    public class ExceptionHandleMiddleware
    {
        private readonly ILogger<ExceptionHandleMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandleMiddleware(ILogger<ExceptionHandleMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContent)
        {
            try
            {
                await next(httpContent);
            }
            catch (Exception e)
            {
                var errorId = Guid.NewGuid();
                logger.LogError(e, $"{errorId} : {e.Message}");
                httpContent.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContent.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong! We are looking into resolving this."
                };

                await httpContent.Response.WriteAsJsonAsync(error);
            }
        } 
    }
}

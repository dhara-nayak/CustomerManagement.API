namespace CustomerManagement.API.Middlewares
{
    
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseCustomeExceptionMiddleware (this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}

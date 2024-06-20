
namespace MiddlewareExample
{
    public class TestMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello from TestMiddleware app.Map()\n");
            await next(context); // for next middleware is called
        }
    }
}

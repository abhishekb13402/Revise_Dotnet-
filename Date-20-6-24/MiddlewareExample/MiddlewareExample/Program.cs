using MiddlewareExample;

var builder = WebApplication.CreateBuilder(args);
// Register the TestMiddleware in the DI container
builder.Services.AddTransient<TestMiddleware>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseMiddleware<TestMiddleware>();
//app.UseMiddleware<RequestResponseLoggingMiddleware>();

//custom one middleware

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("middleware-1");
//});

//Run method can not go in next meddleware

// multiple middleware
//next is a RequestDelegate
app.Use(async (context,next) =>
{
    await context.Response.WriteAsync("middleware-1\n");
    await next(context);
    await context.Response.WriteAsync("After 3rd middleware next");
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("middleware-2\n");
    await context.Response.WriteAsync("Before next\n");

    await next(context);//next middleware
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("middleware-3\n");
});


//default to run app
app.Run();

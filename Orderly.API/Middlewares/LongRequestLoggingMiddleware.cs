
using MediatR;
using System.Diagnostics;

namespace Orderly.API.Middlewares;

public class LongRequestLoggingMiddleware(ILogger<LongRequestLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

        var watch = Stopwatch.StartNew();
        await next.Invoke(context);
        watch.Stop();

        if(watch.ElapsedMilliseconds >= 4000)
        {
            logger.LogInformation("{@RequestMethod} {@RequestPath} responded in {@ElapsedMilliseconds} ms. ", context.Request.Method, context.Request.Path.Value, watch.ElapsedMilliseconds );
        }

    }
}

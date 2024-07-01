using System.Net;
using ToDoService.Logic.Exceptions;

namespace ToDoListService.Host.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private const string ErrorResponseContentType = "text/plain";

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (RequestContentException rcex)
        {
            context.Response.ContentType = ErrorResponseContentType;
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(rcex.Message);
        }
        catch (NotFoundException nfex)
        {
            context.Response.ContentType = ErrorResponseContentType;
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsync(nfex.Message);
        }
        catch
        {
            context.Response.ContentType = ErrorResponseContentType;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync("InternalError");
        }
    }
}
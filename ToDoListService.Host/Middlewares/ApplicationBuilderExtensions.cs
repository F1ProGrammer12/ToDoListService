namespace ToDoListService.Host.Middlewares;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder) 
        => builder.UseMiddleware<ExceptionHandlingMiddleware>();
}
namespace DbOperationWithEFcore.Middleware
{
    public class GlobalExceptionHandlingCustomMiddleware
    {
        private readonly RequestDelegate next;

        public GlobalExceptionHandlingCustomMiddleware(RequestDelegate rd)
        {
            this.next = rd;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var xs = context.GetEndpoint();
                context.Items["Data"] = "GlobalExceptionHandlingCustomMiddleware";
                var x = context.Items["Data"];
                Console.WriteLine($"Before");
                await next(context);
                Console.WriteLine($"After");
            }
            catch (Exception ex)
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync($"Error in Controller: {context.Request.RouteValues["controller"]} and Method:{context.Request.RouteValues["action"]}");
                }
                else
                {
                    Console.WriteLine($"Error occurred but response already started: {ex.Message}");
                }
            }
        }
    }
}

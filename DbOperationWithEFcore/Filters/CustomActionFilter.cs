using Microsoft.AspNetCore.Mvc.Filters;

namespace DbOperationWithEFcore.Filters
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Code to execute before the action method is called
            // For example, you can log the request or modify the action parameters
            Console.WriteLine("Before action");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("After action");
        }

    }
}

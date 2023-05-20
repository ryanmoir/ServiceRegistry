namespace ServiceRegistory.Api.Attributes
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Serilog;
    using System.Linq;
    using System.Net.Http;

    public class LogApiRequestAttribute : ActionFilterAttribute
    {
        public async override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;

            var requestMeth = request.Method;

            var headerDict = request.Headers.ToDictionary(x => x.Key, x => x.Value);

            var contentString = string.Empty;
            using (var content = new StreamContent(request.Body))
                contentString = await content.ReadAsStringAsync();

            var logger = Log.ForContext<LogApiRequestAttribute>();
        }
    }
}
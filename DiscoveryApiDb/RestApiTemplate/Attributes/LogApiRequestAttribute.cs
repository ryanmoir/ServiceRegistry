namespace DiscoveryService.Api.Attributes
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

            var headersStr = string.Empty;
            for (int i = 0; i < request.Headers.Count(); i++)
            {
                var header = request.Headers.ElementAt(i);
                if (i != 0)
                {
                    headersStr = headersStr + " || ";
                }
                headersStr = headersStr + header.Key + " - " + header.Value;
            }

            var contentString = string.Empty;
            using (var content = new StreamContent(request.Body))
            {
                contentString = content.ReadAsStringAsync().Result;
            }

            var logger = Log.ForContext<LogApiRequestAttribute>();
            ///do whatever u want with the request info
        }
    }
}

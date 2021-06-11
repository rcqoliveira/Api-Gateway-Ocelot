using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.GetewayApi
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;
        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();
            
            var result = JObject.Parse(await FormatRequest(context.Request))
                                .Descendants()
                                .OfType<JProperty>()
                                .Select(p => new KeyValuePair<string, object>(p.Path, p.Value.Type == JTokenType.Array || p.Value.Type == JTokenType.Object ? null : p.Value));
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {

            using var reader = new StreamReader(
                request.Body,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            var formattedRequest = $" {request.QueryString} {body}";
            request.Body.Position = 0;
            return formattedRequest;
        }
    }
}
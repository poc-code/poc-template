using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Poc_Template_Domain.Interfaces.Notifications;


namespace Poc_Template_Api.Filters
{
    public class DomainNotificationFilter : IAsyncResultFilter
    {
        private readonly IDomainNotification _domainNotification;

        public DomainNotificationFilter(IDomainNotification domainNotification)
        {
            _domainNotification = domainNotification;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!context.ModelState.IsValid || _domainNotification.HasNotifications)
            {
                var validations = !context.ModelState.IsValid ?
                    JsonSerializer.Serialize(context.ModelState.Values
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)) :
                    JsonSerializer.Serialize(_domainNotification.Notifications
                        .Select(x => x.Value));

                var problemDetails = new ProblemDetails
                {
                    Title = "Bad Request",
                    Status = StatusCodes.Status400BadRequest,
                    Instance = context.HttpContext.Request.Path.Value,
                    Detail = validations
                };

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/problem+json";

                var jsonString = JsonSerializer.Serialize(problemDetails);

                byte[] bytess = Encoding.ASCII.GetBytes(jsonString);
                var data = new MemoryStream(bytess);
                data.Position = 0;

                var responseBody = new StreamReader(data).ReadToEnd();
                UTF8Encoding utf8 = new UTF8Encoding(true, true);
                var memoryStreamModified = new MemoryStream();
                var sw = new StreamWriter(memoryStreamModified, utf8);
                sw.Write(responseBody);
                sw.Flush();
                memoryStreamModified.Position = 0;
                
                Stream originalBody = context.HttpContext.Response.Body;

                await memoryStreamModified.CopyToAsync(originalBody).ConfigureAwait(false);
                return;
            }

            await next();
        }
    }
}

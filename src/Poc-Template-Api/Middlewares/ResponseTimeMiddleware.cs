using Microsoft.AspNetCore.Http;
using Poc_Template_Api.ViewModel;
using System;
using System.Buffers;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Poc_Template_Api.Middlewares
{
    public class ResponseTimeMiddleware
    {
        RequestDelegate _next;

        public ResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Stream originalBody = context.Response.Body;

            try
            {
                using (var buffer = new MemoryStream())
                {
                    var stream = context.Response.Body;
                    context.Response.Body = buffer;
                    
                    await _next.Invoke(context);
                    
                    buffer.Seek(0, SeekOrigin.Begin);
                    var reader = new StreamReader(buffer);
                    
                    using (var bufferReader = new StreamReader(buffer))
                    {
                        string body = await bufferReader.ReadToEndAsync();
                        var objResponse = JsonSerializer.Deserialize<object>(body);

                        var response = new ApiGenericResponse();

                        response.Message = "meu texto";
                        response.Value = objResponse;

                        var jsonString = JsonSerializer.Serialize(response);

                        byte[] bytess = Encoding.ASCII.GetBytes(jsonString);
                        var data = new MemoryStream(bytess);
                        data.Position = 0;

                        var responseBody = new StreamReader(data).ReadToEnd();

                        var memoryStreamModified = new MemoryStream();
                        var sw = new StreamWriter(memoryStreamModified);
                        sw.Write(responseBody);
                        sw.Flush();
                        memoryStreamModified.Position = 0;

                        await memoryStreamModified.CopyToAsync(originalBody).ConfigureAwait(false);
                    }
                }
            }
            finally
            {
                context.Response.Body = originalBody;
            }

        }
    }
}

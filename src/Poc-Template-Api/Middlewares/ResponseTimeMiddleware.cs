using Microsoft.AspNetCore.Http;
using Poc_Template_Api.ViewModel;
using System;
using System.Buffers;
using System.Collections.Generic;
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
            if (context.Request.Path.Value.Contains("api/v1/"))
            {
                await TimeResponseAsync(context);
            }
            else
            {
                await _next.Invoke(context);
            }
        }

        internal async Task TimeResponseAsync(HttpContext context)
        {
            Stream originalBody = context.Response.Body;

            try
            {
                using (var buffer = new MemoryStream())
                {
                    var stream = context.Response.Body;
                    context.Response.Body = buffer;

                    Stopwatch cronometro = new Stopwatch();
                    cronometro.Start();

                    await _next.Invoke(context);

                    var verbsexcluds = new List<string> { "DELETE", "PUT" };
                    if (verbsexcluds.Contains(context.Request.Method))
                        return;

                    buffer.Seek(0, SeekOrigin.Begin);
                    var reader = new StreamReader(buffer);

                    using (var bufferReader = new StreamReader(buffer))
                    {
                        string body = await bufferReader.ReadToEndAsync();
                        var options = new JsonDocumentOptions
                        {
                            CommentHandling = JsonCommentHandling.Skip,
                        };

                        object objResponse = null;
                        //if (body.GetType() == typeof(object))
                        objResponse = JsonSerializer.Deserialize<object>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        var response = new ApiGenericResponse();

                        response.Message = "solicitação processada";
                        response.Value = objResponse;
                        response.Status = (HttpStatusCode)context.Response.StatusCode;
                        cronometro.Stop();
                        response.ProcessTime = $"{(cronometro.ElapsedMilliseconds / 1000.0)} segundos.";

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace LineBot.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            await _next.Invoke(context);
        }

        /// <summary>
        /// 讀取 HTTP Request 的 Body 資料
        /// </summary>
        /// <param name="context">HTTP 的上下文</param>
        /// <returns></returns>
        private string ReadRequestBody(HttpContext context)
        {
            // 確保 HTTP Request 可以多次讀取
            context.Request.EnableBuffering();
            // 讀取 HTTP Request Body 內容
            // 注意！要設定 leaveOpen 屬性為 true 使 StreamReader 關閉時，HTTP Request 的 Stream 不會跟著關閉

            using (var bodyReader = new StreamReader(stream: context.Request.Body,
                                                      encoding: Encoding.UTF8,
                                                      detectEncodingFromByteOrderMarks: false,
                                                      bufferSize: 1024
                                                      ))
            {
                var body = bodyReader.ReadToEnd();

                // 將 HTTP Request 的 Stream 起始位置歸零
                context.Request.Body.Position = 0;

                return body;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestMiddleware>();
        }
    }
}

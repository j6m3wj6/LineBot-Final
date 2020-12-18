using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using LineBot.Middlewares;

namespace LineBot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            //app÷.UseRequestMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapPost("/api/linebot", async context =>
                //{
                //    string ChannelAccessToken = "YuCo+fV3bAEAHkqI4FHvs0gYlPDlaASLoII49mCJfJFC9dbay5ij0M3p/7zn0Z65eVKhD7t0gGqAkBRlg8BcyFZXVDcUDxFNg8f2bAkmLjU2yM37ZvU8UZ9/OcVAaK0C6kP4pss/vb0spdnDREJ/KwdB04t89/1O/w1cDnyilFU=";
                //    //context.Request.EnableBuffering();

                //    var bodyReader = new StreamReader(stream: context.Request.Body,
                //                                                encoding: Encoding.UTF8,
                //                                                detectEncodingFromByteOrderMarks: false,
                //                                                bufferSize: 1024,
                //                                                leaveOpen: true);

                //    //var body = bodyReader.ReadToEnd();

                //    // 將 HTTP Request 的 Stream 起始位置歸零
                //    //context.Request.Body.Position = 0;
                //    //var ReceivedMessage = isRock.LineBot.Utility.Parsing(body);
                //    //回覆訊息
                //    string Message;
                //    //Message = "你說了:" + ReceivedMessage.events[0].message.text;
                //    Message = "Hello, world";
                //    //回覆用戶
                //    //isRock.LineBot.Utility.ReplyMessage(ReceivedMessage.events[0].replyToken, Message, ChannelAccessToken);
                //    //回覆API OK
                //    isRock.LineBot.Utility.PushMessage("Uee40dcf0ca8f874fe5c5b374edccd59b", Message, ChannelAccessToken);
                //    await context.Response.WriteAsync("Hello World!");


                //});
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
            
        }
    }
}

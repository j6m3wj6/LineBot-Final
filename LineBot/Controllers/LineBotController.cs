using LineBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LineBot.Controllers
{
    [Route("api/linebot")]
    [ApiController]
    [Produces("application/json")]
    public class LineChatController : ControllerBase
    {
        [HttpPost]
        public async Task<isRock.LineBot.ReceivedMessage> Post()
        {
            string ChannelAccessToken = "YuCo+fV3bAEAHkqI4FHvs0gYlPDlaASLoII49mCJfJFC9dbay5ij0M3p/7zn0Z65eVKhD7t0gGqAkBRlg8BcyFZXVDcUDxFNg8f2bAkmLjU2yM37ZvU8UZ9/OcVAaK0C6kP4pss/vb0spdnDREJ/KwdB04t89/1O/w1cDnyilFU=";
            //取得 http Post RawData(should be JSON)
            //Console.WriteLine("Request.Body", Request.HttpContext);
            var body = "";
            using (var bodyReader = new StreamReader(stream: Request.Body,
                                                      encoding: Encoding.UTF8,
                                                      detectEncodingFromByteOrderMarks: false,
                                                      bufferSize: 1024
                                                      ))
            {
                body = await bodyReader.ReadToEndAsync();
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(body);
                string Message = "你說了:" + ReceivedMessage.events[0].message.text;

                isRock.LineBot.Utility.ReplyMessage(ReceivedMessage.events[0].replyToken, Message, ChannelAccessToken);
                // 將 HTTP Request 的 Stream 起始位置歸零
                //Request.Body.Position = 0;

                return ReceivedMessage;
            }
            //string postData = Request.Body.ReadAsync();
            //剖析JSON
            //var ReceivedMessage = isRock.LineBot.Utility.Parsing(Body);
            //回覆訊息
            //string Message;
            //Message = "你說了:" + ReceivedMessage.events[0].message.text;
            //Message = "Hello, world";
            //回覆用戶
            //isRock.LineBot.Utility.ReplyMessage(ReceivedMessage.events[0].replyToken, Message, ChannelAccessToken);
            //回覆API OK
            //isRock.LineBot.Utility.PushMessage("Uee40dcf0ca8f874fe5c5b374edccd59b", Message, ChannelAccessToken);

            //return Request.Body.ToString();
        }
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //完整的路由網址就是 https://xxx/api/linebot/run
        //[HttpPost("run")]
        //public async Task<IActionResult> Post()
        //{
        //    return Ok();
        //}
    }
}

using LineBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace LineBot.Controllers
{
    public class LineChatController : ControllerBase
    {
        [HttpPost]
        public ActionResult POST()
        {
            string ChannelAccessToken = "YuCo+fV3bAEAHkqI4FHvs0gYlPDlaASLoII49mCJfJFC9dbay5ij0M3p/7zn0Z65eVKhD7t0gGqAkBRlg8BcyFZXVDcUDxFNg8f2bAkmLjU2yM37ZvU8UZ9/OcVAaK0C6kP4pss/vb0spdnDREJ/KwdB04t89/1O/w1cDnyilFU=";

            try
            {
                //取得 http Post RawData(should be JSON)
                Console.WriteLine("Request.Body", Request.Body);
                string postData = Request.Body.ToString();
                //剖析JSON
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);
                //回覆訊息
                string Message;
                Message = "你說了:" + ReceivedMessage.events[0].message.text;
                //回覆用戶
                isRock.LineBot.Utility.ReplyMessage(ReceivedMessage.events[0].replyToken, Message, ChannelAccessToken);
                //回覆API OK
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok();
            }

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

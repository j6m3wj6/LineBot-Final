using LineBot.Models;
using LineBot.Repositories;
using LineBot.App;
using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace LineBot.Controllers
{
    public class BOT : isRock.LineBot.Bot
    {
        public string userId { get; set; }
        public int state { get; set; }
        public string module { get; set; }
        public List<string> userInput { get; set; }
        public DateTime license { get; set; }

        public BOT(string userId, string ChannelAccessToken) : base(ChannelAccessToken)
        {
            this.userId = userId;
            this.license = DateTime.Now;
            this.state = 0;
            this.module = "firstLogin";
            this.userInput = new List<string>();
        }
        public void CheckLicence()
        {
            if (DateTime.Compare(this.license.AddMinutes(1), DateTime.Now) < 0)
            {
                ResetState();
            }
        }
        public void UpdateLicence()
        {
            this.license = DateTime.Now;
        }
        public void ResetState()
        {
            this.license = DateTime.Now;
            this.state = 0;
            this.module = "home";
            this.userInput = new List<string>();
        }
        //public async string testAsync ()
        //{

        //    return "";
        //}
    }

    [Route("api/linebot")]
    [ApiController]
    [Produces("application/json")]
    public class LineChatController : ControllerBase
    {
        static string ChannelAccessToken = "YuCo+fV3bAEAHkqI4FHvs0gYlPDlaASLoII49mCJfJFC9dbay5ij0M3p/7zn0Z65eVKhD7t0gGqAkBRlg8BcyFZXVDcUDxFNg8f2bAkmLjU2yM37ZvU8UZ9/OcVAaK0C6kP4pss/vb0spdnDREJ/KwdB04t89/1O/w1cDnyilFU=";
        static string AdminUserId = "Uee40dcf0ca8f874fe5c5b374edccd59b";
        //static isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);
        static List<BOT> botPool = new List<BOT>();

        //static BOT bot = new BOT(ChannelAccessToken);

        HomeworkManager _hwManager = new HomeworkManager();
        UserManager _userManager = new UserManager();

        public LineChatController():base()
        {
            //richMenu(ChannelAccessToken);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
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
                var ev = ReceivedMessage.events[0];
                var userId = ev.source.userId;

                var bot = botPool.Find(b => b.userId == userId);
                if (bot == null)
                {
                    bot = new BOT(userId, ChannelAccessToken);
                    botPool.Add(bot);
                }
                bot.CheckLicence();
                try
                {
                    if (ev.type == "postback")
                    {
                        //isRock.LineBot.Utility.ReplyMessage(ev.replyToken, "postback", ChannelAccessToken);

                        var queryStr = QueryHelpers.ParseQuery(ev.postback.data);
                        if (queryStr["action"].ToString() == "handInHomework")
                        {
                            bot.module = "handInHomework";
                            //isRock.LineBot.Utility.ReplyMessage(ev.replyToken, "handInHomework", ChannelAccessToken);
                        }

                    }
                    switch (bot.module)
                    {
                        case "handInHomework":
                            await _hwManager.HandIn(bot, ev);
                            break;
                        case "firstLogin":
                            await _userManager.FillInfo(bot, ev);
                            break;
                        default:
                            isRock.LineBot.Utility.ReplyMessage(ev.replyToken, "hello", ChannelAccessToken);
                            break;
                    }
                }
                catch (HomeworkManagerException hwE)
                {
                    isRock.LineBot.Utility.ReplyMessage(ev.replyToken, hwE.Message, ChannelAccessToken);
                    bot.ResetState();
                }
                catch
                {
                    isRock.LineBot.Utility.ReplyMessage(ev.replyToken, "error", ChannelAccessToken);
                    bot.ResetState();
                }
                return Ok();
            }
        }

        //public RedirectToRouteResult RedirectToRoute()
        //{
        //    return RedirectToRoute(new { controller = "Home", action = "Route" });
        //}
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //完整的路由網址就是 https://xxx/api/linebot/run
        [HttpPost("handin")]
        public async Task<string> PostTest()
        {
            //return RedirectToAction("Complete", new { id = 123 });
            return "redirect";
        }

        //public void richMenu(string Token)
        //{
        //    //建立RuchMenu
        //    var item1 = new isRock.LineBot.RichMenu.RichMenuItem();
        //    //var item2 = new isRock.LineBot.RichMenu.RichMenuItem();
        //    item1.name = "no name";
        //    item1.chatBarText = "快捷選單A";
        //    item1.selected = true;
        //    //item2.name = "no name";
        //    //item2.chatBarText = "快捷選單B";
        //    //item2.selected = true;

        //    //建立左上方按鈕區塊
        //    var leftupButton = new isRock.LineBot.RichMenu.Area();
        //    leftupButton.bounds.x = 0;
        //    leftupButton.bounds.y = 0;
        //    leftupButton.bounds.width = 1250;
        //    leftupButton.bounds.height = 1686 / 2;
        //    leftupButton.action = new MessageAction() { label = "左上", text = "我要交作業" };
        //    //建立右上方按鈕區塊
        //    var rightupButton = new isRock.LineBot.RichMenu.Area();
        //    rightupButton.bounds.x = 1250;
        //    rightupButton.bounds.y = 0;
        //    rightupButton.bounds.width = 1250 + 1250;
        //    rightupButton.bounds.height = 1686 / 2;
        //    rightupButton.action = new MessageAction() { label = "右上", text = "請假" };
        //    //建立左下方按鈕區塊
        //    var leftdownButton = new isRock.LineBot.RichMenu.Area();
        //    leftdownButton.bounds.x = 0;
        //    leftdownButton.bounds.y = 1686 / 2;
        //    leftdownButton.bounds.width = 1250;
        //    leftdownButton.bounds.height = 1686 / 2;
        //    leftdownButton.action = new MessageAction() { label = "左下", text = "補課" };
        //    //建立右下方按鈕區塊
        //    var rightdownButton = new isRock.LineBot.RichMenu.Area();
        //    rightdownButton.bounds.x = 1250;
        //    rightdownButton.bounds.y = 1686 / 2;
        //    rightdownButton.bounds.width = 1250 + 1250;
        //    rightdownButton.bounds.height = 1686 / 2;
        //    rightdownButton.action = new MessageAction() { label = "右下", text = "成績查詢" };

        //    //將area加入RichMenuItem
        //    item1.areas.Add(leftupButton);
        //    item1.areas.Add(rightupButton);
        //    item1.areas.Add(rightdownButton);
        //    item1.areas.Add(leftdownButton);

        //    //建立Menu Item並綁定指定的圖片
        //    var menu1 = isRock.LineBot.Utility.CreateRichMenu(
        //        item1, new Uri("https://img.onl/uS9qJc"), ChannelAccessToken);
        //    isRock.LineBot.Utility.SetDefaultRichMenu(menu1.richMenuId, ChannelAccessToken);


        //}
    }
    

}

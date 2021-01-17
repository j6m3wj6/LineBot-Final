using LineBot.Models;
using LineBot.Repositories;
using LineBot.Components;
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
        public BOT(string ChannelAccessToken) : base(ChannelAccessToken)
        {
            this.license = DateTime.Now;
            this.state = 0;
            this.module = "firstLogin";
            this.userInput = new List<string>();
        }
        public BOT(string userId, string ChannelAccessToken) : base(ChannelAccessToken)
        {
            this.userId = userId;
            this.license = DateTime.Now;
            this.state = 0;
            this.module = "home";
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
            this.userInput.Clear();
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
        static string ChannelAccessToken = "p9hJDxgsiPr5L1l7mIaersSPu9uUvymNW2pSUGQEno6eUZ7GKqSH0vxTEjvLMH3WBpGixeNMlRWsjjHxVm0TZbiFYR3AeyeQbZ7LRoRh1dgy6oE1E2gZj30RMns4FkJknga38ubqu7PhjQDMlTG3zQdB04t89/1O/w1cDnyilFU=";
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
            //Read Http post request bit stream
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
                //bot.PushMessage(userId, $"bot for user {userId}, {bot.module}");

                var bot = botPool.Find(b => b.userId == userId);

                try
                {
                    if (bot == null)
                    {
                        bot = new BOT(userId, ChannelAccessToken);
                        botPool.Add(bot);
                        bot.PushMessage(userId, $"New user");
                    }
                    bot.CheckLicence();

                    if (ev.type == "postback")
                    {
                        //Set the bot module according to postback event (options on the richMenu)
                        var queryStr = QueryHelpers.ParseQuery(ev.postback.data);
                        bot.module = queryStr["action"].ToString();
                    } 
                    switch (bot.module)
                    {
                        case "handInHomework":
                            await _hwManager.HandIn(bot, ev);
                            break;
                        case "scoreStatics":
                            await _userManager.ScoreStatics(bot, ev);
                            break;
                        case "firstLogin":
                            await _userManager.FillInfo(bot, ev);
                            break;
                        default:
                            JSONrewrite jSONrewrite = new JSONrewrite();
                            //jSONrewrite.Test();
                            //Utility.PushMessages(userId, jSONrewrite.Test(), ChannelAccessToken);
                            //bot.PushMessageWithJSON(userId, "hello");
                            //bot.PushMessageWithJSON(userId, jSONrewrite.Test());
                            bot.PushMessageWithJSON(userId, FlexMessage.getFlex());

                            //bot.PushMessage(userId, );
                            break;
                    }
                }
                catch (ExceptionManager hwE)
                {
                    bot.PushMessage(userId, $"執行錯誤\n" +
                        $"--------\n" +
                        $"Module: {hwE.module}\n" +
                        $"Message: {hwE.Message}");
                    bot.ResetState();
                }
                catch (Exception e)
                {
                    bot.PushMessage(userId, $"執行錯誤\n" +
                        $"--------\n" +
                        $"Module: unknown\n" +
                        $"Source: {e.Source}\n" +
                        $"ExceptionType:\n {e.Data}\n" +
                        $"Message: {e.ToString()}");
                    bot.PushMessage(userId, $"請重新操作一次\n");

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
    }
    

}

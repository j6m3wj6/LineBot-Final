using System;
using LineBot.Controllers;
using LineBot.Repositories;
using LineBot.Models;
using isRock.LineBot;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace LineBot.App
{

    public class UserManager
    {
        static HomeworkServicies _hwServicies = new HomeworkServicies();
        static UsersServicies _userServicies = new UsersServicies();
        static ClassServicies _classServicies = new ClassServicies();
        static string ChannelAccessToken = "p9hJDxgsiPr5L1l7mIaersSPu9uUvymNW2pSUGQEno6eUZ7GKqSH0vxTEjvLMH3WBpGixeNMlRWsjjHxVm0TZbiFYR3AeyeQbZ7LRoRh1dgy6oE1E2gZj30RMns4FkJknga38ubqu7PhjQDMlTG3zQdB04t89/1O/w1cDnyilFU=";

        //static string AdminUserId = "Uee40dcf0ca8f874fe5c5b374edccd59b";

        public UserManager()
        {

        }
        public async Task<string> FillInfo(BOT bot, Event ev)
        {
            //USER stu = _userServicies.Get(studentId);
            bot.UpdateLicence();
            switch (bot.state)
            {
                case (0):
                    isRock.LineBot.Utility.ReplyMessage(ev.replyToken, "請問您的學號是?", ChannelAccessToken);
                    bot.state++;
                    break;
                case (1):
                    if (!CheckStudentIdFormat(ev.message.text))
                        isRock.LineBot.Utility.ReplyMessage(ev.replyToken, $"錯誤格式: 請重新輸入學號", ChannelAccessToken);
                    else
                    {
                        USER user = _userServicies.Get(ev.message.text);
                        if (user == null)
                            isRock.LineBot.Utility.ReplyMessage(ev.replyToken, $"找不到學號: 請重新輸入學號", ChannelAccessToken);
                        else
                        {
                            bot.userId = user.StudentId;
                            bot.ResetState();
                        }
                    }
                    break;
                
                default:
                    isRock.LineBot.Utility.ReplyMessage(ev.replyToken, "FillInfo", ChannelAccessToken);
                    break;
            }
            //return RedirectToAction("Complete", new { id = 123 });
            return "FillInfo";
        }
        public bool CheckStudentIdFormat(string input)
        {
            bool result = true;
            if (!Regex.IsMatch(input, @"^stu_[1-9][0-9]*$"))
            {
                result = false;
            }
            return result;
        }

        public async Task<string> ScoreStatics(BOT bot, Event ev)
        {
            //USER stu = _userServicies.Get(studentId);
            bot.UpdateLicence();
            switch (bot.state)
            {
                case (0):
                    isRock.LineBot.Utility.ReplyMessage(ev.replyToken, "請問您的學號是?", ChannelAccessToken);
                    bot.state++;
                    bot.ResetState();
                    break;
                //case (1):
                //    if (!CheckStudentIdFormat(ev.message.text))
                //        isRock.LineBot.Utility.ReplyMessage(ev.replyToken, $"錯誤格式: 請重新輸入學號", ChannelAccessToken);
                //    else
                //    {
                //        USER user = _userServicies.Get(ev.message.text);
                //        if (user == null)
                //            isRock.LineBot.Utility.ReplyMessage(ev.replyToken, $"找不到學號: 請重新輸入學號", ChannelAccessToken);
                //        else
                //        {
                //            //_userServicies.
                //            bot.module = "home";
                //            bot.state = 0;
                //        }
                //    }
                //    break;

                default:
                    isRock.LineBot.Utility.ReplyMessage(ev.replyToken, "ScoreStatics", ChannelAccessToken);
                    break;
            }
            //return RedirectToAction("Complete", new { id = 123 });
            return "ScoreStatics";
        }

    }
}

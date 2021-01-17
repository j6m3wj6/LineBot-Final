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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;


namespace LineBot.App
{
    public class HomeworkManager
    {
        static HomeworkServicies _hwServicies = new HomeworkServicies();
        static UsersServicies _userServicies = new UsersServicies();
        static ClassServicies _classServicies = new ClassServicies();

        static string ChannelAccessToken = "YuCo+fV3bAEAHkqI4FHvs0gYlPDlaASLoII49mCJfJFC9dbay5ij0M3p/7zn0Z65eVKhD7t0gGqAkBRlg8BcyFZXVDcUDxFNg8f2bAkmLjU2yM37ZvU8UZ9/OcVAaK0C6kP4pss/vb0spdnDREJ/KwdB04t89/1O/w1cDnyilFU=";
        static string AdminUserId = "Uee40dcf0ca8f874fe5c5b374edccd59b";

        public HomeworkManager()
        {
        }
        public async Task<string> HandIn(BOT bot, Event ev)
        {
            bot.UpdateLicence();
            try
            {
                switch (bot.state)
                {
                    case (0):
                        isRock.LineBot.Utility.ReplyMessage(ev.replyToken, "請問您的學號是?", ChannelAccessToken);
                        bot.state++;
                        break;
                    case (1):
                        if (!CheckInput("studentId", ev.message.text))
                            isRock.LineBot.Utility.ReplyMessage(ev.replyToken, $"錯誤格式: 請重新輸入學號", ChannelAccessToken);
                        else
                        {
                            bot.userInput.Add(ev.message.text);
                            ButtonsTemplate ButtonsTemplateMsg = GetUndoHW(ev.message.text);
                            bot.PushMessage(AdminUserId, ButtonsTemplateMsg);
                            bot.state++;
                        }
                        break;
                    case (2):
                        //checkInput

                        bot.userInput.Add(ev.message.text);
                        isRock.LineBot.Utility.ReplyMessage(ev.replyToken, $"開始繳交{ev.message.text}\n請問您1-5題答案是?", ChannelAccessToken);
                        bot.state++;
                        break;
                    case (3):
                        //checkInput
                        if (!CheckInput("answer", ev.message.text))
                            isRock.LineBot.Utility.ReplyMessage(ev.replyToken, $"錯誤格式: 請重新輸入1-5題答案", ChannelAccessToken);
                        else
                        {
                            bot.userInput.Add(ev.message.text);
                            isRock.LineBot.Utility.ReplyMessage(ev.replyToken, "請問您6-10題答案是?", ChannelAccessToken);
                            bot.state++;
                        }
                        break;
                    case (4):
                        //checkInput
                        if (!CheckInput("answer", ev.message.text))
                            isRock.LineBot.Utility.ReplyMessage(ev.replyToken, $"錯誤格式: 請重新輸入6-10題答案", ChannelAccessToken);
                        else
                        {
                            bot.userInput.Add(ev.message.text);
                            //Compare with the answer
                            string resJson = CompareWithAnswer(bot);
                            dynamic resObj = JsonConvert.DeserializeObject(resJson);

                            isRock.LineBot.Utility.ReplyMessage(ev.replyToken, $"結束作答: \n" +
                                $"您輸入的答案： {resObj.userInput}\n" +
                                $"正確答案： {resObj.answer}\n" +
                                $"分數：{resObj.score}\n" +
                                $"錯誤率：{resObj.errorRate}\n", ChannelAccessToken);

                            bot.state = 0;
                            bot.module = "home";
                        }
                        break;
                    default:
                        isRock.LineBot.Utility.ReplyMessage(ev.replyToken, "HandInHomeWorkManager", ChannelAccessToken);
                        break;
                }
            }
            catch (HomeworkManagerException e)
            {
                throw e;
            }
            //return RedirectToAction("Complete", new { id = 123 });
            return "HandInHomeWorkManager";
        }

        public ButtonsTemplate GetUndoHW(string studentId)
        {
            List<HOMEWORK> undoHWs = JsonConvert.DeserializeObject<List<HOMEWORK>>(_userServicies.GetUnDueHW(studentId));
            var actions = new List<TemplateActionBase>();
            ButtonsTemplate ButtonsTemplateMsg;
            if (undoHWs.Count() == 0)
            {
                ButtonsTemplateMsg = new ButtonsTemplate
                {
                    altText = "無法顯示時的替代文字",
                    thumbnailImageUrl = new Uri("https://arock.blob.core.windows.net/blogdata201709/14-143030-1cd8cf1e-8f77-4652-9afa-605d27f20933.png"),
                    title = "您沒有未交的作業",
                    text = "",
                    //actions = actions,
                };
            }
            else
            {
                ButtonsTemplateMsg = new ButtonsTemplate
                {
                    altText = "無法顯示時的替代文字",
                    thumbnailImageUrl = new Uri("https://arock.blob.core.windows.net/blogdata201709/14-143030-1cd8cf1e-8f77-4652-9afa-605d27f20933.png"),
                    title = "繳交作業",
                    text = "請問您想繳交哪個作業？",
                    actions = actions,
                };
            }
            foreach (HOMEWORK hw in undoHWs)
            {
                actions.Add(new MessageAction() { label = hw.Title, text = hw.HomeworkId });
            }

            return ButtonsTemplateMsg;
        }
        public bool CheckInput(string dialogue, string input)
        {
            bool result = true;
            switch (dialogue)
            {
                case ("answer"):
                    result = CheckAnswerFormat(input);
                    break;
                case ("studentId"):
                    result = CheckStudentIdFormat(input);
                    break;
                default: break;
            }
            return result;
        }

        public bool CheckStudentIdFormat(string input)
        {
            bool result = true;
            if (!Regex.IsMatch(input, @"^stu_[1-4][0-9]*$"))
            {
                result = false;
            }
            return result;
        }

        public bool CheckAnswerFormat(string input)
        {
            bool result = true;
            if (input.Length != 5) result = false;
            if (!Regex.IsMatch(input, @"^[a-eA-E]*$"))
            {
                result = false;
            }
            return result;
        }

        public string CompareWithAnswer(BOT bot)
        {

            HOMEWORK hw = _hwServicies.Get(bot.userInput[1]);
            char[] right_ans = hw.Answers;
            char[] student_ans = (bot.userInput[2]+bot.userInput[3]).ToArray();

            if (right_ans.Length != student_ans.Length)
                throw new HomeworkManagerException("輸入題數與資料不符");
            
            int error = 0; //錯誤題數
            //對答案 回傳錯誤率
            for (int i = 0; i < right_ans.Length; i++)
            {
                if (char.ToUpper(right_ans[i]) != char.ToUpper(student_ans[i]))
                    error = error + 1;
            }
            var result = new
            {
                answer = string.Join(" ", right_ans),
                userInput = string.Join(" ", student_ans),
                errorRate = error / Convert.ToDouble(right_ans.Length),
                score = 100 * (1 - error / Convert.ToDouble(right_ans.Length)),
            };


            string resultJson = JsonConvert.SerializeObject(result);
            return resultJson; //除以總題數
        }




        //public static char[] UserAnswer(string ans)
        //{
        //    //將string變char陣列
        //    char[] arr = new char[ans.Length];
        //    arr = ans.ToCharArray();
        //    return arr;
        //}
    }

    class HomeworkManagerException : Exception
    {
        public HomeworkManagerException(string message)
            : base(message)
        {
        }
    }
}

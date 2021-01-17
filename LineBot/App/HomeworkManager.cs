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

        public HomeworkManager()
        {

        }
        public async Task<string> HandIn(BOT bot, Event ev)
        {
            var userId = ev.source.userId;

            bot.UpdateLicence();
            try
            {
                switch (bot.state)
                {
                    case (0):
                        bot.PushMessage(userId, "請問您的學號是?");
                        bot.state++;
                        break;
                    case (1):
                        if (!CheckInput("studentId", ev.message.text))
                            bot.PushMessage(userId, "錯誤格式: 請重新輸入學號");
                        else
                        {
                            bot.userInput.Add(ev.message.text);
                            ButtonsTemplate ButtonsTemplateMsg = GetUndoHW(ev.message.text);
                            bot.PushMessage(userId, ButtonsTemplateMsg);
                            bot.state++;
                        }
                        break;
                    case (2):
                        //put into list
                        bot.userInput.Add(ev.message.text);
                        bot.PushMessage(userId, $"開始繳交{ev.message.text}\n請問您1-5題答案是?");
                        bot.state++;
                        break;
                    case (3):
                        //checkInput
                        if (!CheckInput("answer", ev.message.text))
                                bot.PushMessage(userId, $"錯誤格式: 請重新輸入1-5題答案");
                        else
                        {
                            bot.userInput.Add(ev.message.text);
                            bot.PushMessage(userId, "請問您6-10題答案是?");
                            bot.state++;
                        }
                        break;
                    case (4):
                        //checkInput
                        if (!CheckInput("answer", ev.message.text))
                            bot.PushMessage(userId, $"錯誤格式: 請重新輸入6-10題答案");
                        else
                        {
                            bot.userInput.Add(ev.message.text);
                            //Compare with the answer
                            string resJson = CompareWithAnswer(bot);
                            dynamic resObj = JsonConvert.DeserializeObject(resJson);
                            string mes = $"結束作答！\n" +
                                $"{resObj.hwTitle} ({resObj.hwId})\n" +
                                $"---------\n" +
                                $"您的答案： {resObj.userInput}\n" +
                                $"正確答案： {resObj.answer}\n" +
                                $"分數：{resObj.score}\n" +
                                $"錯誤率：{resObj.errorRate}\n";
                            bot.PushMessage(userId, mes);
                            UpdateScore(bot.userInput[0], bot.userInput[1], resObj.score);
                            bot.state = 0;
                            bot.module = "home";
                        }
                        break;
                    default:
                        bot.PushMessage(userId, "HandInHomeWorkManager");
                        break;
                }
            }
            catch (ExceptionManager e)
            {
                throw e;
            }
            return "HandInHomeWorkManager";
        }
        static public void UpdateScore(string studentId, string homeworkId, double score)
        {
            _userServicies.UpdateScore(studentId, homeworkId, score);
        }


        static public ButtonsTemplate GetUndoHW(string studentId)
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
        static public bool CheckInput(string dialogue, string input)
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

        static public bool CheckStudentIdFormat(string input)
        {
            bool result = true;
            if (!Regex.IsMatch(input, @"^stu_[1-4][0-9]*$"))
            {
                result = false;
            }
            return result;
        }

        static public bool CheckAnswerFormat(string input)
        {
            bool result = true;
            if (input.Length != 5) result = false;
            if (!Regex.IsMatch(input, @"^[a-eA-E]*$"))
            {
                result = false;
            }
            return result;
        }

        static public string CompareWithAnswer(BOT bot)
        {

            HOMEWORK hw = _hwServicies.Get(bot.userInput[1]);
            char[] right_ans = hw.Answers;
            char[] student_ans = (bot.userInput[2]+bot.userInput[3]).ToArray();

            if (right_ans.Length != student_ans.Length)
                throw new ExceptionManager("HandIn", "輸入題數與資料不符");
            
            int error = 0; //錯誤題數
            //對答案 回傳錯誤率
            for (int i = 0; i < right_ans.Length; i++)
            {
                if (char.ToUpper(right_ans[i]) != char.ToUpper(student_ans[i]))
                    error = error + 1;
            }
            var result = new
            {
                hwTitle = hw.Title,
                hwId = hw.HomeworkId,
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

    
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LineBot.Components
{
    public class JSONrewrite
    {
        int DataCount=3;

        JsonTemplate JsonTemplate=new JsonTemplate();


        const string studentNameRoute = "contents[0].body.contents[0].contents[0].contents[1].text";

        const string OutPutTableRouteLessonBasic = "contents[0].body.contents[4].contents[1].";

        const string OutPutGraphRouteGradeHeighBtasic = "contents[0].body.contents[8].contents[1].contents[2].";

        public string OutPutGraphRouteGradeHeighSelect(int lesson)
        {
            return "contents["+(lesson-1).ToString()+"].contents[0].height";
        }
        public string OutPutTableRouteLessonSelect(int lessonNum)//第幾筆成績的課程資料
        {
            return "contents["+(lessonNum*2).ToString()+"].contents[0].contents[0].text";
        }

        public string OutPutTableRouteGradeSelect(int lessonNum)//第幾筆成績的成績資料
        {
            return "contents[" + (lessonNum *2).ToString() + "].contents[2].contents[0].text";
        }


        public void readJSON(string DataName)
        {

            string output="";


            Console.WriteLine(JsonTemplate.Json);

            JObject objJObject = JObject.Parse(JsonTemplate.Json);

            JToken objToken = objJObject.SelectToken(OutPutGraphRouteGradeHeighBtasic+ OutPutGraphRouteGradeHeighSelect(1));
            if (objToken == null)
            {
                output = "not found";
                Console.WriteLine(output);

            }
            else
            { 
                output+= objToken.Value<string>() + "\r\n";
                Console.WriteLine(output);

            }

            return;

        }
        public string Test()
        {
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JsonTemplate.Test);
            dynamic jsonObj_push = Newtonsoft.Json.JsonConvert.DeserializeObject(JsonTemplate.Json);
            //Console.WriteLine(jsonObj);
            //Console.WriteLine(jsonObj.body["contents"]);
            Console.WriteLine(jsonObj_push);
            Console.WriteLine(jsonObj_push[0]["contents"]);
            jsonObj_push[0]["contents"].Append(jsonObj);
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj_push, Newtonsoft.Json.Formatting.Indented);


            return output;
        }
        public void RewriteGrade(string lesson, string grade, int beRewrite)//成績覆寫
                                                                            //目前是三個空位lesson是要輸入的課號(?) grade是成績 beRewrite是要被覆蓋的件數(1-3)
        {

            


            //var result = new
            //{
            //    type = "flex",
            //    altText = "This is a Flex Message",
            //    contents = jsonObj,
            //};
            //string result_Json = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            //Console.WriteLine(result);

            //[
            //    {
            //                ""type"": ""flex"",
            //    ""altText"": ""This is a Flex Message"",
            //    ""contents"": [
            //            {

            //                }
            //        ]
            //    }
            //]
            //詳細統計部分
            //覆寫課程名稱
            //contents[0].body.contents[4].contents[1]."contents["+(lessonNum*2).ToString()+"].contents[0].contents[0].text"
            //jsonObj["contents"][0]["body"]["contents"][4]["contents"][1]["contents"][beRewrite*2]["contents"][0]["contents"][0]["text"] = lesson;
            //覆寫課程成績
            //contents[0].body.contents[4].contents[1]."contents["+(lessonNum*2).ToString()+"].contents[2].contents[0].text"
            //jsonObj["contents"][0]["body"]["contents"][4]["contents"][1]["contents"][beRewrite * 2]["contents"][2]["contents"][0]["text"] = grade;

            //圖表部分
            //複寫圖表高度
            //contents[0].body.contents[8].contents[1].contents[2].contents["+(lesson-1).ToString()+"].contents[0].height
            //jsonObj["contents"][0]["body"]["contents"][8]["contents"][1]["contents"][2]["contents"][beRewrite-1]["contents"][0]["height"] = Math.Round((100-double.Parse(grade))).ToString()+"px";
            //複寫圖表下標名稱
            //contents►0►body►contents►8►contents►3►contents►2►contents►0►contents►0►text
            //jsonObj["contents"][0]["body"]["contents"][8]["contents"][3]["contents"][2]["contents"][beRewrite - 1]["contents"][0]["text"] = lesson;

            //string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);

            //File.WriteAllText("E:\\LineBot\\20210116\\localtest\\localtest\\test.txt", output);
        }

        public void DynamicInsertGrade(int lesson,string grade)
        {
            //詳細統計部分
            //contents[0].body.contents[4].contents[1]."contents["+(lessonNum*2).ToString()+"].contents[0].contents[0].text"
            //雙引號那段要整段添加



            //圖表部分
            //contents[0].body.contents[8].contents[1].contents[2]."contents[" + (lesson - 1).ToString() + "].contents[0].height"
            //雙引號那段要整段添加
            
        }




    }
}
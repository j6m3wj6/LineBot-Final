using isRock.LineBot;
using System;
using System.Collections.Generic;
using LineBot.Models;
using LineBot.Repositories;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;

namespace LineBot
{
    public class LineBotBasic
    {
        static string ChannelAccessToken = "YuCo+fV3bAEAHkqI4FHvs0gYlPDlaASLoII49mCJfJFC9dbay5ij0M3p/7zn0Z65eVKhD7t0gGqAkBRlg8BcyFZXVDcUDxFNg8f2bAkmLjU2yM37ZvU8UZ9/OcVAaK0C6kP4pss/vb0spdnDREJ/KwdB04t89/1O/w1cDnyilFU=";
        static string AdminUserId = "Uee40dcf0ca8f874fe5c5b374edccd59b";
        static isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);

        static MongoClient client = new MongoClient("mongodb+srv://j6m3wj6:0000@cluster0.gnphr.mongodb.net/LineBotCramSchool?retryWrites=true&w=majority");
        static IMongoDatabase database = client.GetDatabase("LineBotCramSchool");
        static IMongoCollection<USER> _users = database.GetCollection<USER>("Users");

        public static void main()
        {
            /*
            //text();
            //sticker();
            //picture();
            //buttonsTemplate();
            //confirmTemplate();
            //carouselTemplate();
            //quickReply();
            //liffApp();
            //richMenu();
            */


            //Create();
            Receive();
            //DeleteAll();
            Update();

            Console.WriteLine("End of LineBotBasic");
            
        }
        public static void Create()
        {

            string[] classes1 = { "phys_A1", "math_B4" };
            string[] classes2 = { "phys_A1", "engilsh_C2" };

            var newUser1 = new USER("User1", "stu_001");
            var newUser2 = new USER("User2", "stu_002");
            var newUser3 = new USER("User3", "stu_003");

            //newUser1.info();

            List<USER> data = new List<USER>();
            data.Add(newUser1);
            data.Add(newUser2);
            data.Add(newUser3);
            _users.InsertMany(data);
        }

        public static void Receive()
        {
            List<USER> resData = new List<USER>();
            var cursor1 = _users.Find(user => true).ToCursor();
            foreach (var document in cursor1.ToEnumerable())
            {
                Console.WriteLine(document);
                resData.Add(document);
            }
            foreach (var data in resData)
                data.info();
            //Console.WriteLine(result1);
            //var firstDocument = _users.Find(new BsonDocument()).FirstOrDefault().ToJson();
            //Console.WriteLine(firstDocument);
            //Console.WriteLine(BsonSerializer.Deserialize<User>(firstDocument));
        }
        public static void Delete()
        {
            //var deleteLowExamFilter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>("scores",
            //     new BsonDocument { { "type", "exam" }, {"score", new BsonDocument { { "$lt", 60 }}}
            //});
            //collection.DeleteMany(deleteLowExamFilter);
            var deleteFilter = Builders<USER>.Filter.Eq("name", "User1");
            //_users.DeleteOne(deleteFilter);
        }
        public static void DeleteAll ()
        {
            _users.DeleteMany(Builders<USER>.Filter.Empty);
        }
        public static void Update()
        {
            List<UserClass> classes = new List<UserClass>();
            classes.Add(new UserClass("phys_A1"));
            classes.Add(new UserClass("math_B4"));

            var filter = Builders<USER>.Filter.Eq("Name", "User3");
            var update = Builders<USER>.Update.Set("Classes", classes);
            _users.UpdateOne(filter, update);
            //var arrayFilter = Builders<User>.Filter.Eq("name", "User3")
            //                 & Builders<User>.Filter.Eq("scores.type", "quiz");
            //var arrayUpdate = Builders<User>.Update.Set("scores.$.score", 84.92381029342834);
            //collection.UpdateOne(arrayFilter, arrayUpdate);
        }




        public static void text()
        {
            bot.PushMessage(AdminUserId, "hello");
        }
        public static void sticker()
        {
            bot.PushMessage(AdminUserId, 1, 13);
        }
        public static void picture()
        {
            Uri imgURL = new Uri("https://arock.blob.core.windows.net/blogdata201706/22-124357-ad3c87d6-b9cc-488a-8150-1c2fe642d237.png");
            bot.PushMessage(AdminUserId, imgURL);
        }
        public static void buttonsTemplate()
        {
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.MessageAction() { label = "男裝", text = "man" });
            actions.Add(new isRock.LineBot.MessageAction() { label = "女裝", text = "women" });
            actions.Add(new isRock.LineBot.MessageAction() { label = "童裝", text = "children" });

            var ButtonsTemplateMsg = new isRock.LineBot.ButtonsTemplate();
            ButtonsTemplateMsg.altText = "無法顯示時的替代文字";
            ButtonsTemplateMsg.thumbnailImageUrl = new Uri("https://arock.blob.core.windows.net/blogdata201709/14-143030-1cd8cf1e-8f77-4652-9afa-605d27f20933.png");
            ButtonsTemplateMsg.text = "請問您想購買哪一類的服飾?";
            ButtonsTemplateMsg.title = "詢問";
            ButtonsTemplateMsg.actions = actions;

            bot.PushMessage(AdminUserId, ButtonsTemplateMsg);
        }
        public static void confirmTemplate()
        {
            //建立一個Buttons Template Message物件
            var ConfirmTemplateMsg = new isRock.LineBot.ConfirmTemplate();
            //設定thumbnailImageUrl
            ConfirmTemplateMsg.altText = "無法顯示時的替代文字";
            ConfirmTemplateMsg.text = "請問您想選擇的是?";
            //建立actions
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.MessageAction() { label = "同意", text = "yes" });
            actions.Add(new isRock.LineBot.MessageAction() { label = "拒絕", text = "no" });
            //將建立好的actions選項加入
            ConfirmTemplateMsg.actions = actions;
            //send ConfirmTemplateMsg
            bot.PushMessage(AdminUserId, ConfirmTemplateMsg);
        }
        public static void carouselTemplate()
        {
            //建立actions，作為ButtonTemplate的用戶回覆行為
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.MessageAction() { label = "標題-文字回覆", text = "回覆文字" });
            actions.Add(new isRock.LineBot.UriAction() { label = "標題-Google", uri = new Uri("http://www.google.com") });
            actions.Add(new isRock.LineBot.PostbackAction() { label = "標題-發生postack", data = "abc=aaa&def=111" });

            //單一Column 
            var Column = new isRock.LineBot.Column
            {
                text = "ButtonsTemplate文字訊息",
                title = "ButtonsTemplate標題",
                //設定圖片
                thumbnailImageUrl = new Uri("https://arock.blob.core.windows.net/blogdata201709/14-143030-1cd8cf1e-8f77-4652-9afa-605d27f20933.png"),
                actions = actions //設定回覆動作
            };

            //建立CarouselTemplate
            var CarouselTemplate = new isRock.LineBot.CarouselTemplate();

            //這是範例，所以用一組樣板建立三個
            CarouselTemplate.columns.Add(Column);
            CarouselTemplate.columns.Add(Column);
            CarouselTemplate.columns.Add(Column);

            //發送 CarouselTemplate
            bot.PushMessage(AdminUserId, CarouselTemplate);
        }
        public static void quickReply()
        {
            isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("請問你要請什麼假別?");

            msg.quickReply.items.Add(
                new isRock.LineBot.QuickReplyMessageAction(
                    "特休", "特休", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_resolutions-25_897228.png")));
            msg.quickReply.items.Add(
                new isRock.LineBot.QuickReplyMessageAction(
                    "事假", "事假", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));
            msg.quickReply.items.Add(
                new isRock.LineBot.QuickReplyMessageAction(
                    "病假", "病假", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));

            bot.PushMessage(AdminUserId, msg);
        }
        public static void liffApp()
        {
            //Liff format = "line://app/1655280488-PM2XpBMw";
            string LiffURL = "https://testliff.azurewebsites.net/default.html";
            var Liff = isRock.LIFF.Utility.AddLiffApp(
                ChannelAccessToken, new Uri(LiffURL), isRock.LIFF.ViewType.tall);
            //Console.WriteLine(Liff);
            bot.PushMessage(AdminUserId, Liff);
        }
        public static void richMenu()
        {
            //建立RuchMenu
            var item1 = new isRock.LineBot.RichMenu.RichMenuItem();
            var item2 = new isRock.LineBot.RichMenu.RichMenuItem();
            item1.name = "no name";
            item1.chatBarText = "快捷選單A";
            item1.selected = true;
            item2.name = "no name";
            item2.chatBarText = "快捷選單B";
            item2.selected = true;

            //建立左方按鈕區塊
            var leftButton = new isRock.LineBot.RichMenu.Area();
            leftButton.bounds.x = 0;
            leftButton.bounds.y = 0;
            leftButton.bounds.width = 460;
            leftButton.bounds.height = 1686;
            leftButton.action = new MessageAction() { label = "左", text = "/左" };
            //建立右方按鈕區塊
            var rightButton = new isRock.LineBot.RichMenu.Area();
            rightButton.bounds.x = 2040;
            rightButton.bounds.y = 0;
            rightButton.bounds.width = 2040 + 460;
            rightButton.bounds.height = 1686;
            rightButton.action = new MessageAction() { label = "右", text = "/右" };

            //將area加入RichMenuItem
            item1.areas.Add(leftButton);
            item1.areas.Add(rightButton);

            item2.areas.Add(leftButton);
            item2.areas.Add(rightButton);

            //建立Menu Item並綁定指定的圖片
            var menu1 = isRock.LineBot.Utility.CreateRichMenu(
                    item1, new Uri("http://arock.blob.core.windows.net/blogdata201902/test01.png"), ChannelAccessToken);
            var menu2 = isRock.LineBot.Utility.CreateRichMenu(
                 item2, new Uri("http://arock.blob.core.windows.net/blogdata201902/03-223328-2405ca23-08e4-404b-8df5-db625177bbd4.png"), ChannelAccessToken);

            isRock.LineBot.Utility.SetDefaultRichMenu(menu1.richMenuId, ChannelAccessToken);


        }

        public LineBotBasic()
        {
            
        }
    }
}

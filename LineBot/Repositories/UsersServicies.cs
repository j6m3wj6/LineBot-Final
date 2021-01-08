using System;
using LineBot.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace LineBot.Repositories
{
    public class UsersServicies
    {
        private readonly IMongoCollection<BsonDocument> _users;

        public UsersServicies() //IUsersDatabaseSettings settings
        {
            var client = new MongoClient("mongodb+srv://j6m3wj6:0000@cluster0.gnphr.mongodb.net/LineBotCramSchool?retryWrites=true&w=majority");
            var database = client.GetDatabase("LineBotCramSchool");
            Console.Write("UsersServicies initialize", database);
            _users = database.GetCollection<BsonDocument>("Users");
            //var document = new BsonDocument {
            //    { "UserName", "Test" }
            //};
            //_users.InsertOne(document);
            //var coll = database.GetCollection<User>("Users");  //指定寫入給"categories"此collection,但我們的資料型態是Category  
            //List<User> data = new List<User>();
            //data.Add(new User { UserName = "Test1" });
            //data.Add(new User { UserName = "Test2" });
            //coll.InsertMany(data);
            
        }

        public String Get()
        {
            string result1 = string.Empty;
            var cursor1 = _users.Find(user => true).ToCursor();
            foreach (var document in cursor1.ToEnumerable())
            {
                //Console.WriteLine(document);
                result1 += document.ToJson();
            }
            Console.WriteLine(result1);
            return result1;
        }

        //public User Get(string id) =>
        //    _users.Find<User>(user => user.Id == id).FirstOrDefault();

        //public User Create(User user)
        //{
        //    _users.InsertOne(user);
        //    return user;
        //}

        //public void Update(string id, User userIn) =>
        //    _users.ReplaceOne(user => user.Id == id, userIn);

        //public void Remove(User userIn) =>
        //    _users.DeleteOne(user => user.Id == userIn.Id);

        //public void Remove(string id) =>
        //    _users.DeleteOne(user => user.Id == id);

    }
}

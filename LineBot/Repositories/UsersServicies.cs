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
        private readonly IMongoCollection<USER> _users;

        public UsersServicies() //IUsersDatabaseSettings settings
        {
            var client = new MongoClient("mongodb+srv://j6m3wj6:0000@cluster0.gnphr.mongodb.net/LineBotCramSchool?retryWrites=true&w=majority");
            var database = client.GetDatabase("LineBotCramSchool");
            Console.Write("UsersServicies initialize", database);
            _users = database.GetCollection<USER>("Users");
            
        }

        public List<USER> Get()
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
            return resData;
        }

        //public User Get(string id) =>
        //    _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public USER Create(USER user)
        {
            _users.InsertOne(user);
            return user;
        }
        public List<USER> CreateMany(List<USER> users)
        {
            _users.InsertMany(users);
            return users;
        }

        public void DeleteOne(FilterDefinition<USER> filter)
        {
            _users.DeleteOne(filter);
        }
        public void DeleteAll()
        {
            _users.DeleteMany(Builders<USER>.Filter.Empty);
        }

        public static void Update()
        {
            //List<UserClass> classes = new List<UserClass>();
            //classes.Add(new UserClass("phys_A1"));
            //classes.Add(new UserClass("math_B4"));

            //var filter = Builders<USER>.Filter.Eq("Name", "User3");
            //var update = Builders<USER>.Update.Set("Classes", classes);
            //_users.UpdateOne(filter, update);
            //var arrayFilter = Builders<User>.Filter.Eq("name", "User3")
            //                 & Builders<User>.Filter.Eq("scores.type", "quiz");
            //var arrayUpdate = Builders<User>.Update.Set("scores.$.score", 84.92381029342834);
            //collection.UpdateOne(arrayFilter, arrayUpdate);
        }

        //public void Update(string id, User userIn) =>
        //    _users.ReplaceOne(user => user.Id == id, userIn);

        //public void Remove(User userIn) =>
        //    _users.DeleteOne(user => user.Id == userIn.Id);

        //public void Remove(string id) =>
        //    _users.DeleteOne(user => user.Id == id);

    }
}

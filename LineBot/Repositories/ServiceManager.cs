using System;
using LineBot.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace LineBot.Repositories
{
    abstract class ServiceManager<T>
    {
        protected readonly IMongoCollection<T> _collection;
        static MongoClient client = new MongoClient("mongodb+srv://j6m3wj6:0000@cluster0.gnphr.mongodb.net/LineBotCramSchool?retryWrites=true&w=majority");
        static IMongoDatabase database = client.GetDatabase("LineBotCramSchool");

        public ServiceManager(string collectionName) //IUsersDatabaseSettings settings
        {
            _collection = database.GetCollection<T>(collectionName);
        }
        public IQueryable GetAll()
        {
            return _collection.AsQueryable();
        }
        public List<T> Get()
        {
            List<T> resData = new List<T>();
            var cursor = _collection.Find(item => true).ToCursor();

            foreach (var document in cursor.ToEnumerable())
            {
                resData.Add(document);
            }

            return resData;
        }

        public T Create(T user)
        {
            _collection.InsertOne(user);
            return user;
        }

        public List<T> CreateMany(List<T> items)
        {
            _collection.InsertMany(items);
            return items;
        }

        public void DeleteOne(FilterDefinition<T> filter)
        {
            _collection.DeleteOne(filter);
        }
        public void DeleteAll()
        {
            _collection.DeleteMany(Builders<T>.Filter.Empty);
        }
        public static string Info()
        {
            return "";
        }

        public static void Update()
        {
            //List<UserClass> classes = new List<UserClass>();
            //classes.Add(new UserClass("phys_A1"));
            //classes.Add(new UserClass("math_B4"));

            //var filter = Builders<HOMEWORK>.Filter.Eq("Name", "User3");
            //var update = Builders<HOMEWORK>.Update.Set("Classes", classes);
            //_users.UpdateOne(filter, update);
            //var arrayFilter = Builders<User>.Filter.Eq("name", "User3")
            //                 & Builders<User>.Filter.Eq("scores.type", "quiz");
            //var arrayUpdate = Builders<User>.Update.Set("scores.$.score", 84.92381029342834);
            //collection.UpdateOne(arrayFilter, arrayUpdate);
        }

    }
}
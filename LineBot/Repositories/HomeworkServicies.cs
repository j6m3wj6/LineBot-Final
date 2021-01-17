using System;
using LineBot.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace LineBot.Repositories
{
    class HomeworkServicies : ServiceManager<HOMEWORK>
    {
        //private readonly IMongoCollection<USER> _users;

        public HomeworkServicies():base("Homework") //IUsersDatabaseSettings settings
        {
            //var client = new MongoClient("mongodb+srv://j6m3wj6:0000@cluster0.gnphr.mongodb.net/LineBotCramSchool?retryWrites=true&w=majority");
            //var database = client.GetDatabase("LineBotCramSchool");
            //Console.Write("UsersServicies initialize", database);
            //_users = database.GetCollection<USER>("Users");
            //_users = new ServiceManager<USER>("Users");
        }

        public HOMEWORK Get(string homeworkId)
        {
            return _collection.Find(hw => hw.HomeworkId == homeworkId).FirstOrDefault();
        }
        public Boolean Due(string homeworkId)
        {
            HOMEWORK target = this.Get(homeworkId);
            DateTime hwDueTime = target.DueTime;
            Console.WriteLine($"now: {DateTime.Now.ToString("MM/dd/yyyy HH:mm")}");

            if (DateTime.Compare(hwDueTime, DateTime.Now) < 0)
            {
                Console.WriteLine($"{target.Title} is dued at {hwDueTime}");
                return true;
            }
            Console.WriteLine($"{target.Title} is still availible");
            return false;
        }
    }
}

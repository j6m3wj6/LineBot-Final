using System;
using LineBot.Models;
using LineBot.App;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace LineBot.Repositories
{
    class UsersServicies : ServiceManager<USER>
    {
        public UsersServicies():base("Users") //IUsersDatabaseSettings settings
        {
        }

        public USER Get(string studentId)
        {
            USER user = _collection.Find(user => user.StudentId == studentId).FirstOrDefault();
            Console.Write(user.StudentId);
            return user;
        }
        public string GetUnDueHW (string studentId)
        {
            USER stu = Get(studentId);
            Console.WriteLine($"Student {stu.Name} (id: {stu.StudentId}) --> undueHomework");

            HomeworkServicies _hwServicies = new HomeworkServicies();
            List<HOMEWORK> undueHW = new List<HOMEWORK>();

            if (stu.Classes != null)
            {
                foreach (var cls in stu.Classes)
                {
                    if (cls.Homework != null)
                    {
                        foreach (UserHomework data in cls.Homework)
                        {
                            HOMEWORK hw = _hwServicies.Get(data.HomewoerkId);
                            if (!_hwServicies.Due(hw.HomeworkId))
                            {
                                undueHW.Add(hw);
                            }
                        }
                    }
                }
            }
            string undueHWJson = JsonConvert.SerializeObject(undueHW);
            Console.WriteLine(undueHWJson);
            return undueHWJson;
        }
        public void UpdateScore(string studentId, string HomeworkId, double score)
        {
            USER stu = Get(studentId);
            Console.WriteLine($"Student {stu.Name} (id: {stu.StudentId}) --> updateScore");
            bool result = false;
            foreach(var cls in stu.Classes)
            {
                foreach(var hw in cls.Homework)
                {
                    if (hw.HomewoerkId == HomeworkId)
                    {
                        result = true;
                        hw.Status = true;
                        hw.Score = score;
                    }
                }
            }
            if (!result) throw new ExceptionManager("userServicies",
                "Cant't find target homework to update score");

        }
        public void getScore(string studentId)
        {

        }
    }
}

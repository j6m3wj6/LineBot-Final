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
        //public void BindLineId(string lineId)
        //{

        //}
        public string GetUnDueHW (string studentId)
        {
            USER stu = Get(studentId);
            Console.WriteLine($"Student {stu.Name} (id: {stu.StudentId}) --> undueHomework");

            HomeworkServicies _hwServicies = new HomeworkServicies();
            List<HOMEWORK> undueHW = new List<HOMEWORK>();

            try
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
            catch (Exception e)
            {
                throw new ExceptionManager("UsersServicies", "stu.Classes is null\n" + e.Message);
            }
            string undueHWJson = JsonConvert.SerializeObject(undueHW);
            Console.WriteLine(undueHWJson);
            return undueHWJson;
        }
        public string GetUnDoHW(string studentId)
        {
            USER stu = Get(studentId);
            Console.WriteLine($"Student {stu.Name} (id: {stu.StudentId}) --> undueHomework");

            HomeworkServicies _hwServicies = new HomeworkServicies();
            List<HOMEWORK> undueHW = new List<HOMEWORK>();

            try
            {
                foreach (var cls in stu.Classes)
                {
                    if (cls.Homework != null)
                    {
                        foreach (UserHomework data in cls.Homework)
                        {
                            if (!data.Status)
                            {
                                HOMEWORK hw = _hwServicies.Get(data.HomewoerkId);
                                undueHW.Add(hw);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new ExceptionManager("UsersServicies", "stu.Classes is null\n" + e.Message);
            }
            string undueHWJson = JsonConvert.SerializeObject(undueHW);
            Console.WriteLine(undueHWJson);
            return undueHWJson;
        }
        public string UpdateScore(string studentId, string homeworkId, double score)
        {

            USER stu = Get(studentId);
            //List<UserClass> newCls = new List<UserClass>();
            //Console.WriteLine($"Student {stu.Name} (id: {stu.StudentId}) --> updateScore");
            bool result = false;
            foreach (var cls in stu.Classes)
            {
                foreach (var hw in cls.Homework)
                {
                    if (hw.HomewoerkId == homeworkId)
                    {
                        result = true;
                        hw.Status = true;
                        hw.Score = score;
                    }
                }
            }
            try
            {
                var filter = Builders<USER>.Filter.Eq("StudentId", studentId);
                var update = Builders<USER>.Update.Set("Classes", stu.Classes);
                _collection.UpdateOne(filter, update);

                //_collection.UpdateOne(x => x.StudentId == studentId, Builders<USER>.Update.Set(x => x, stu));
                //_collection.FindOneAndUpdate(x => x.StudentId == studentId
                //    && x.Classes.Any(c => c.Homework.Any(hw => hw.HomewoerkId == homeworkId)),
                //    Builders<USER>.Update.Set(x => x.Classes[-1].Homework[-1].Status, true)
                //                         .Set(x => x.Classes[-1].Homework[-1].Score, score));
            }
            catch
            {
                throw new ExceptionManager("userServicies",
                $"Cant't find target homework to update score {result}");
            }


            return studentId + homeworkId + score;

            //if (!result) throw new ExceptionManager("userServicies",
            //"Cant't find target homework to update score");

        }
        public void getScore(string studentId)
        {

        }
    }
}

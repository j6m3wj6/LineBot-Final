using System;
using LineBot.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace LineBot.Repositories
{
    class ClassServicies : ServiceManager<CLASS>
    {
        public ClassServicies() : base("Class") 
        {
        }
        public CLASS Get(string classId)
        {
            return _collection.Find(cls => cls.ClassId == classId).FirstOrDefault();
        }
        public List<USER> GetStudents(string classId)
        {
            
            CLASS cls = _collection.Find(cls => cls.ClassId == classId).FirstOrDefault();
            Console.WriteLine($"Get students from {cls.Name} (id: {cls.ClassId}) ");

            UsersServicies _userServicies = new UsersServicies();
            List<USER> students = new List<USER>();

            if (cls.Students != null)
            {
                foreach (var stu in cls.Students)
                {
                    USER user = _userServicies.Get(stu);
                    students.Add(user);
                }
            }
            return students;
        }
        public async void AddStudent(string classId, string studentId)
        {
            CLASS cls = this.Get(classId);
            var filter = Builders<CLASS>.Filter.Eq("ClassId", classId);

            if (cls.Students == null)
            {
                await _collection.UpdateOneAsync(filter,
                    Builders<CLASS>.Update.Set(u => u.Students, new List<string>()));
            }

            await _collection.UpdateOneAsync(filter,
                    Builders<CLASS>.Update.AddToSet(u => u.Students, studentId));
        }
    }
}

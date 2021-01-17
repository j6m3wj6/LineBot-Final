using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LineBot.Models
{
    public class CLASS
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string Name { get; set; }
		public string ClassId { get; set; }
		public string Teacher { get; set; }
		public List<string> Students { get; set; }
		public List<string> Homework { get; set; }
        //public CLASS(string name, string classId, string teacher, string[] students)
        //{
        //    this.Name = name;
        //    this.ClassId = classId;
        //    this.Teacher = teacher;
        //    this.Students = students;
        //}
    }
}

using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LineBot.Models
{
    public class CLASS
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("name")]
		public string Name { get; set; }

		[BsonElement("classId")]
		public string ClassId { get; set; }

		[BsonElement("teacher")]
		public string Teacher { get; set; }

		[BsonElement("students")]
		public string[] Students { get; set; }

		[BsonElement("homeWork")]
		public string[] Homework { get; set; }

		public CLASS(string name, string classId, string teacher, string[] students)
		{
			this.Name = name;
			this.ClassId = classId;
			this.Teacher = teacher;
			this.Students = students;
		}
		
    }
}

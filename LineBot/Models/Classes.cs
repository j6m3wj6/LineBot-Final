using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LineBot.Models
{
	public class Classes
	{

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("name")]
		public string name { get; set; }

		[BsonElement("classId")]
		public string classId { get; set; }

		[BsonElement("teacher")]
		public string teacher { get; set; }

		[BsonElement("students")]
		public string[] students { get; set; }

		[BsonElement("homeWork")]
		public string homework { get; set; }

		public Classes(string name, string classId, string teacher, string[] students)
		{
			this.name = name;
			this.classId = classId;
			this.teacher = teacher;
			this.students = students;
		}

	}
}
/*
//Classes
{
		_id: ObjectId(5fe5e89fb7b18070d8d18a5d),
		name: STRING,
		classId: STRING,
		teacher: STRING,
		students: [...(studentId)],
		homework: [...(homeWorkId)],
		
		//need discussion
		attendanceStatus: [
				(Day):
		]
	
}
*/
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LineBot.Models
{
	public class Homework
	{

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("homeworkId")]
		public string homeworkId { get; set; }

		[BsonElement("title")]
		public string title { get; set; }

		[BsonElement("description")]
		public string description { get; set; }

		[BsonElement("tags")]
		public string tags { get; set; }

		[BsonElement("startTime")]
		public string startTime { get; set; }

		[BsonElement("dueTime")]
		public string dueTime { get; set; }

		[BsonElement("classId")]
		public string classId { get; set; }

		[BsonElement("answers")]
		public string answers { get; set; }

		[BsonElement("hangingStatus")]
		public string hangingStatus { get; set; }

	}
}
/*
//Homework
{
	_id: ObjectId(5fe5e89fb7b18070d8d18a5d),
	homeworkId: STRING,
	title: STRING,
	description: STRING,
	tags: [STRING]
	startTime: DATE,
	dueTime: DATE,

	classId: STRING,
	answers: {
		(questionId1): STRING,
		(questionId2): STRING,
	},
	
	hangingStatus: {
		(studentId1): [BOOLEAN, FLOAT],
		(studentId2): [BOOLEAN, FLOAT],
		...
	}
}
*/
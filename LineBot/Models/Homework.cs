using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LineBot.Models
{
	public class HOMEWORK
	{

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("homeworkId")]
		public string HomeworkId { get; set; }

		[BsonElement("title")]
		public string Title { get; set; }

		[BsonElement("description")]
		public string Description { get; set; }

		[BsonElement("tags")]
		public string[] Tags { get; set; }

		[BsonElement("startTime")]
		public string StartTime { get; set; }

		[BsonElement("dueTime")]
		public string DueTime { get; set; }

		[BsonElement("classId")]
		public string ClassId { get; set; }

		[BsonElement("answers")]
		public string Answers { get; set; }

		//[BsonElement("hangingStatus")]
		//public string HangingStatus { get; set; }

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
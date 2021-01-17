using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LineBot.Models
{
	class HOMEWORK 
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string HomeworkId { get; set; }

        public string Title { get; set; }

		public string Description { get; set; }

		public string[] Tags { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime DueTime { get; set; }

		public string ClassId { get; set; }

		public char[] Answers { get; set; }

	}


	//List<HOMEWORK> hws = new List<HOMEWORK>();
	//HOMEWORK newHW = new HOMEWORK
	//{
	//	HomeworkId = "hw1",
	//	Title = "math1",
	//	Description = "xxxxx",
	//	ClassId = "math_A1",
	//	Answers = { 'a','b','d','e','a', 'a', 'b', 'd', 'e', 'a' },

	//};
	//hws.Add(newHW);
}


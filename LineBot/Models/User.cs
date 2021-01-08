using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LineBot.Models
{
    public class User
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("studentId")]
        public string studentId { get; set; }

		[BsonElement("lineUserId")]
		public string lineUserId { get; set; }

		[BsonElement("classes")]
		public string[] classes { get; set; }

		public User(string name, string studentId, string[] classes)
        {
			this.name = name;
			this.studentId = studentId;
			//this.lineUserId = lineUserId;
			this.classes = classes;
		}
		public void info()
        {
			string str = "";
			str += this.name;
			str += ' ';
			str += this.studentId;
			str += ' ';
			str += this.lineUserId;
			str += " classes = { ";
			foreach (string cla in classes)
            {
				str += cla;
				str += ' ';
            }
			str += "} \n";

			Console.WriteLine(str);
        }
	}
}
/*
//Users
{
		_id: ObjectId(5fe5e89fb7b18070d8d18a5d),
		name: STRING,
		studentId: STRING,
		lineUserId: STRING,
		
		classes: [
				(classesId1): {
						homeWork: {
								(homeWorkId1): [BOOLEAN, FLOAT],
								(homeWorkId2): [BOOLEAN, FLOAT],
								...
						}
				},
				(classesId2): {
						homeWork: {
								(homeWorkId3): [BOOLEAN, FLOAT],
								(homeWorkId4): [BOOLEAN, FLOAT],
								...
						}
				}
	],

	class: [...(classId)],
	homeWork: {
		(homeWorkId1): [BOOLEAN, FLOAT], //[finished, score]
		(homeWorkId2): [BOOLEAN, FLOAT],
		...
	}
}
*/
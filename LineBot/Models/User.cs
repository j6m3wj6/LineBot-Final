using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LineBot.Models
{
	public class UserHomework
	{
		public string _id { get; set; }
		public Boolean Status { get; set; }
		public float Score { get; set; }
		public string info()
        {
			string str = "";
			str += _id;
			str += ' ';
			str += Status;
			str += ' ';
			str += Score;
			str += '\n';
			return str;
		}
		public UserHomework(Boolean status)
		{
			this.Status = status;
			this.Score = 0;
		}
		public UserHomework(Boolean status, float score)
		{
			this.Status = status;
			this.Score = score;
		}
	}

	public class UserClass
    {
		public string _id { get; set; }
		public string Name { get; set; }
		public List<UserHomework> Homework { get; set; }
		public UserClass(string name)
		{
			this.Name = name;
		}
		public UserClass(List<UserHomework> hws)
		{
			this.Homework = hws;
		}

		public string info()
		{
			string str = "";
			if (_id != null) str += _id;
			str += ' ';
			if (Name != null) str += Name;
			str += ' ';
			if (Homework != null)
            {
				str += "\nhomework: {\n";
				foreach (UserHomework hw in Homework)
				{
					str += hw.info();
				}
				str += "}";
			}
			
			str += "\n";
			return str;

		}
	}

    public class USER
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        //[BsonElement("name")] map to the name in MongoDB
        public string Name { get; set; }
        public string StudentId { get; set; }
        public string LineUserId { get; set; }
        public List<UserClass> Classes { get; set; }
		public USER(string name, string studentId)
		{
			this.Name = name;
			this.StudentId = studentId;
		}
		public USER(string name, string studentId, List<UserClass> classes)
        {
			this.Name = name;
			this.StudentId = studentId;
			//this.lineUserId = lineUserId;
			this.Classes = classes;
		}


		public string info()
        {
			string str = "";
			str += this.Name;
			str += ' ';
			str += this.StudentId;
			str += ' ';
			//str += this.LineUserId;
			
			if (Classes != null)
            {
				str += " \n classes = { \n";
				foreach (UserClass cla in Classes)
				{
					str += cla.info();
				}
				str += "} ";
			}
            
            str += "\n";

            Console.WriteLine(str);
			return str;
        }
		
	}
	
}

/*
public void SerializeClasses ()
		{
			var root = new BsonDocument() { { "class", new BsonDocument() } };
			foreach (var info in this.Classes)
			{
				if (string.IsNullOrWhiteSpace(Class.Definition.TagName))
				{
					continue;
				}
				root["nutrients"][nutrient.Definition.TagName] =
				  new BsonDocument() {
					{"id", nutrient.NutrientId},
					{"amount", nutrient.AmountInHundredGrams},
					{"description", nutrient.Definition.Description},
					{"uom", nutrient.Definition.UnitOfMeasure},
					{"sortOrder", nutrient.Definition.SortOrder}
				  };
			}
			this.Classes = root;
		}

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
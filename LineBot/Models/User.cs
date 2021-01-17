using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LineBot.Models
{
	public class UserHomework 
	{
        public string HomewoerkId { get; set; }
        public Boolean Status { get; set; }
		public double Score { get; set; }

		public UserHomework(string homewoerkId, Boolean status)
		{
			this.HomewoerkId = homewoerkId;
			this.Status = status;
			this.Score = 0;
		}
		public UserHomework(string homewoerkId, Boolean status, double score)
		{
			this.HomewoerkId = homewoerkId;
			this.Status = status;
			this.Score = score;
		}
		public void SetScore(double score)
        {
			this.Score = score;
		}
	}

	public class UserClass
    {
		public string ClassId { get; set; }
		public string Name { get; set; }
		public List<UserHomework> Homework { get; set; }
		public UserClass()
		{
		}
		public UserClass(string name)
		{
			this.Name = name;
		}
		public UserClass(string classId, string name)
		{
			this.Name = name;
			this.ClassId = classId;
		}
		public UserClass(string classId, string name, List<UserHomework> hws)
		{
			this.Name = name;
			this.ClassId = classId;
			this.Homework = hws;
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
		public USER()
		{

		}
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
			
			PropertyInfo[] props = this.GetType().GetProperties();

			var values = props.Select(s => s.GetValue(this, null)).ToList();

            var result = new
            {
                Name = this.Name,
                StudentId = this.StudentId,
                LineUserId = this.LineUserId,
                Classes = from s in this.Classes
                          select s
            };
            string strJson = JsonConvert.SerializeObject(this);

            Console.WriteLine($"info {strJson}");

            return "";
        }
		
	}
	
}

//foreach (PropertyInfo prop in props)
//{
//             if (prop.Name == "Classes")
//             {
//		List<UserClass> useClasses = prop.GetValue(UserClass, null);

//		foreach (var it in prop.GetValue(UserClass, null))
//                 {

//                     Console.WriteLine($"{it.Name}: {prop.GetValue(this, null)}");
//                 }
//             }
//             Console.WriteLine($"{prop.Name}: {prop.GetValue(this, null)}");
//}
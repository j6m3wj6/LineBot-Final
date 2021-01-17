using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LineBot.Models
{
	abstract class MODEL
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		protected string _id { get; set; }

		protected string Id { get; set; }

		protected string Name { get; set; }

		public MODEL()
		{
		}
		public MODEL(string name)
		{
			this.Name = name;
		}
		public MODEL(string id, string name)
		{
			this.Id = id;
			this.Name = name;
		}

	}

}

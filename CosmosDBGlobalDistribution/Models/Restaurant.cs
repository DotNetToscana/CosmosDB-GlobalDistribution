using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Org.DotNetToscana.CosmosDBGlobalDistribution.Models
{
	public class Restaurant
	{

		[BsonId]
		[BsonElement("_id")]
		public ObjectId ObjectId { get; set; }

		[BsonElement("address")]
		public Address Address { get; set; }

		[BsonElement("borough")]
		public string Borough { get; set; }

		[BsonElement("cuisine")]
		public string Cuisine { get; set; }

		[BsonElement("grades")]
		public IEnumerable<Grade> Grades { get; set; }

		[BsonElement("restaurant_id")]
		public string Id { get; set; }

		[BsonElement("name")]
		public string Name { get; set; }
	}
}

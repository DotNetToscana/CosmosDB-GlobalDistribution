using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace Org.DotNetToscana.CosmosDBGlobalDistribution.Models
{
	public class Grade
	{
		[BsonElement("date")]
		public DateTime Date { get; set; }

		[BsonElement("grade")]
		public string Letter { get; set; }

		[BsonElement("score")]
		public int? Score { get; set; }
	}
}
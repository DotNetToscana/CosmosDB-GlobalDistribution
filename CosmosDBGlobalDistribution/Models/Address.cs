using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Org.DotNetToscana.CosmosDBGlobalDistribution.Models
{
	public class Address
	{
		[BsonElement("building")]
		public string Building { get; set; }

		[BsonElement("coord")]
		public IEnumerable<double> Coordinates { get; set; }

		[BsonElement("street")]
		public string Street { get; set; }

		[BsonElement("zipcode")]
		public string ZipCode { get; set; }
	}
}
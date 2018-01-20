using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Org.DotNetToscana.CosmosDBGlobalDistribution.Common;
using Org.DotNetToscana.CosmosDBGlobalDistribution.Models;

namespace Org.DotNetToscana.CosmosDBGlobalDistribution.Services
{
    public class CosmosDbService : IDisposable
    {
        private MongoSettings ConfigurationSettings { get; set; }

        private MongoClient client;
        private MongoClient Client
        {
            set
            {
                client = value;
            }
            get
            {
                if (client == null)
                {
                    var mongoSettings = MongoClientSettings.FromUrl(new MongoUrl(ConfigurationSettings.ConnectionString));
                    mongoSettings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
                    client = new MongoClient(mongoSettings);
                }

                return client;
            }
        }

        public CosmosDbService(IOptions<MongoSettings> settings)
        {
            ConfigurationSettings = settings.Value;
        }

        private IMongoCollection<Restaurant> GetRestaurantsCollection(bool enableReadPreferences)
        {
            var database = Client.GetDatabase(ConfigurationSettings.Database);
            var collection = database.GetCollection<Restaurant>(ConfigurationSettings.Collection);

            if (enableReadPreferences)
            {
                collection = collection.WithReadPreference(ReadPreference.Nearest);
            }

            return collection;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync(int? top = null, bool enableReadPreferences = false)
        {
            var collection = GetRestaurantsCollection(enableReadPreferences);

            var query = collection.Find(new BsonDocument());
            if (top.HasValue)
            {
                query = query.Limit(top.Value);
            }

            var restaurants = await query.ToListAsync();

            return restaurants;
        }

        public void Dispose()
        {
            client = null;
        }
    }
}
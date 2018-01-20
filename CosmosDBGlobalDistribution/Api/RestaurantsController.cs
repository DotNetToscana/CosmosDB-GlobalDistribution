using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.DotNetToscana.CosmosDBGlobalDistribution.Services;
using Org.DotNetToscana.CosmosDBGlobalDistribution.Models;
using System.Diagnostics;

namespace Org.DotNetToscana.CosmosDBGlobalDistribution.Api
{
    [Produces("application/json")]
    [Route("api/restaurants")]
    public class RestaurantsController : Controller
    {
        private readonly CosmosDbService cosmosDbService;

        public RestaurantsController(CosmosDbService cosmosService)
        {
            this.cosmosDbService = cosmosService;
        }

        public async Task<ActionResult> Get(int? top = null, bool enableReadPreferences = false)
        {
            var stopwatch = Stopwatch.StartNew();
            var restaurants = await cosmosDbService.GetRestaurantsAsync(top, enableReadPreferences);
            stopwatch.Stop();

            var result = new Statistics
            {
                RestaurantCount = restaurants.Count(),
                ElapsedMilliseconds = (long)stopwatch.Elapsed.TotalMilliseconds,
                Timestamp = DateTime.Now
            };

            return Ok(result);
        }
    }
}
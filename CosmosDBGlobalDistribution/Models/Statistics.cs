using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.DotNetToscana.CosmosDBGlobalDistribution.Models
{
    public class Statistics
    {
        public int RestaurantCount { get; set; }

        public long ElapsedMilliseconds { get; set; }

        public DateTime Timestamp { get; set; }
    }
}

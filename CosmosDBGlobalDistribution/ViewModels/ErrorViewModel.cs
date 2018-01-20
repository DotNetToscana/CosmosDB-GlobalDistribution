using System;

namespace Org.DotNetToscana.CosmosDBGlobalDistribution.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
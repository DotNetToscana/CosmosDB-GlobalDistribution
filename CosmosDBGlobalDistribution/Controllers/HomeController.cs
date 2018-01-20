using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Org.DotNetToscana.CosmosDBGlobalDistribution.Models;
using Org.DotNetToscana.CosmosDBGlobalDistribution.Services;
using Microsoft.Extensions.Options;
using Org.DotNetToscana.CosmosDBGlobalDistribution.Common;
using Org.DotNetToscana.CosmosDBGlobalDistribution.ViewModels;

namespace Org.DotNetToscana.CosmosDBGlobalDistribution.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
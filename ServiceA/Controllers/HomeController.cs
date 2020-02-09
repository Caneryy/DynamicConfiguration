using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DynamicConfiguration.Model;
using DynamicConfigurator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceA.Models;

namespace ServiceA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ConfigurationReader _configurationReader;

        public HomeController(ILogger<HomeController> logger, ConfigurationReader configurationReader)
        {
            _logger = logger;
            _configurationReader = configurationReader;
        }

        public IActionResult Index()
        {
            //ConfigurationReader configurationReader = new ConfigurationReader("SERVICE-A", "mongodb+srv://caner:Canercan11@firstcluster-j0uon.mongodb.net/test?retryWrites=true&w=majority", 30000);

            ViewBag.caner = _configurationReader.GetValue<string>("SiteName");
            var siteName = _configurationReader.GetValue<string>("SiteName");
            var maxItemCount = _configurationReader.GetValue<int>("MaxItemCount");
            var isBasketEnabled = _configurationReader.GetValue<bool>("IsBasketEnabled");

            ViewBag.siteName = siteName;
            ViewBag.maxItemCount = maxItemCount;
            ViewBag.isBasketEnabled = isBasketEnabled;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

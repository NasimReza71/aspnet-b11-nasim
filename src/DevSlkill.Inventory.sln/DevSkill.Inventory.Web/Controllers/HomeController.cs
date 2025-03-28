using System.Diagnostics;
using DevSkill.Inventory.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Inventory.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IItem _item;

        public HomeController(ILogger<HomeController> logger, IItem item)
        {
            _logger = logger; 
            _item = item;
        }

        public IActionResult Index()
        {
            var amount = _item.GetAmount();
            _logger.LogInformation("This is Nasim Reza");
            _logger.LogInformation("This is a test log entry to verify database logging.");
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

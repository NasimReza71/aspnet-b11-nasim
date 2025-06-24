using DevSkill.Inventory.Web.Areas.Admin.Models.LandingPageModels;
using DevSkill.Inventory.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        public IActionResult ProductImageDashboard()
        {
            var products = new List<ProductViewModel>
                {
                new ProductViewModel { Name = "Burger", ImageUrl = "https://res.cloudinary.com/dmcppzpgl/image/upload/v1741548641/reza_pj0qne.jpg", Stock = -11, StockUnit = "PCS", TodaySale = 0, SaleUnit = "PCS" },
                new ProductViewModel { Name = "Keyboard", ImageUrl = "https://res.cloudinary.com/dph4gugqe/image/upload/v1750791812/HMS/kmmqpb1c70lhvq6a9zdt.png", Stock = 0, StockUnit = "PCS", TodaySale = 0, SaleUnit = "PCS" },
               
                };
            return View(products);
        }

    }
}

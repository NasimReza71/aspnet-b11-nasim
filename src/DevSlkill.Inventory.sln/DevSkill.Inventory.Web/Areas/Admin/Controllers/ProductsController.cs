using DevSkill.Inventory.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            var model = new AddProductModel();
            return View(model); 
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(AddProductModel model)
        {
            if (ModelState.IsValid)
            {
            }

           
            return View(model);
        }

    }
}

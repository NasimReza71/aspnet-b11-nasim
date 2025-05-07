using DevSkill.Inventory.Web.Areas.Admin.Models;
using DevSlkill.Inventory.Domain.Entities;
using DevSlkill.Inventory.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService) 
        {
            _productService = productService;

        } 
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
                _productService.AddProduct(new Product { Name = model.Name });
                //_productService.GetLatestProduct();
            }

           
            return View(model);
        }

    }
}

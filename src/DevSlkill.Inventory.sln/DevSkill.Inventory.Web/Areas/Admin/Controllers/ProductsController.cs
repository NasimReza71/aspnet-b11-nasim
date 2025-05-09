using DevSkill.Inventory.Web.Areas.Admin.Models;
using DevSlkill.Inventory.Application.Features.Products.Commands;
using DevSlkill.Inventory.Domain.Entities;
using DevSlkill.Inventory.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        //private readonly IProductService _productService;
        private readonly IMediator _mediator;
        public ProductsController(IProductService productService, IMediator mediator) 
        {
            _mediator = mediator;
           // _productService = productService;

        } 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            var model = new ProductAddCommand();
            return View(model); 
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ProductAddCommand productAddCommand)
        {
            if (ModelState.IsValid)
            {

                await _mediator.Send(productAddCommand);

                 

                //_productService.AddProduct(new Product {

                //    Name = model.Name,
                //    Price = model.Price,    
                //});

            }


           
            return View(productAddCommand);
        }

    }
}

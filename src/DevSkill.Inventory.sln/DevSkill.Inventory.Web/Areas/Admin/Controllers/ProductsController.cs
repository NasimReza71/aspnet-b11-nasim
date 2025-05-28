using DevSkill.Inventory.Web.Areas.Admin.Models;
using DevSkill.Inventory.Application.Features.Products.Commands;
using DevSkill.Inventory.Application.Services;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using AutoMapper;
using DevSkill.Inventory.Infrastructure;
using DevSkill.Inventory.Application.Exceptions;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductsController(ILogger<ProductsController> logger, 
            IProductService productService, IMediator mediator, IMapper mapper) 
        {
            _logger = logger;
            _mediator = mediator;
            _productService = productService;
            _mapper = mapper;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
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
                try
                {
                    //var product = _mapper.Map<Product>(productAddCommand);
                    await _mediator.Send(productAddCommand);

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Product Added",
                        Type = ResponseTypes.Success
                    });

                    //_productService.AddProduct(new Product {

                    //    Name = model.Name,
                    //    Price = model.Price,    
                    //});
                    return RedirectToAction("ProductList");
                }
                catch(DuplicateProductNameException de)
                {
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = de.Message,
                        Type = ResponseTypes.Danger
                    });
                }

                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to add product");

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Failed to add Product",
                        Type = ResponseTypes.Danger
                    });
                }

            }

            return View(productAddCommand);
        }

        public IActionResult Update(Guid id)
        {
            var model = new UpdateProductModel();
            var product = _productService.GetProduct(id);

            _mapper.Map(product, model);
            return View(model);
        }




        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Update(UpdateProductModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var product = _mapper.Map<Product>(model);

                    _productService.Update(product);

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Product updated",
                        Type = ResponseTypes.Success
                    });

                    return RedirectToAction("ProductList");
                }
                catch (DuplicateProductNameException dpe)
                {
                    ModelState.AddModelError("DuplicateProduct", dpe.Message);
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = dpe.Message,
                        Type = ResponseTypes.Danger
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to update product");

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Failed to update product",
                        Type = ResponseTypes.Danger
                    });
                }
            }

            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productService.DeleteProduct(id);
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Product deleted",
                    Type = ResponseTypes.Success
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete product");

                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Failed to delete product",
                    Type = ResponseTypes.Danger
                });
            }
            return RedirectToAction("ProductList");
        }


        [HttpPost]
        public JsonResult GetProductsJsonData([FromBody] ProductListModel model)
        {
            try
            {
                var (data, total, totalDisplay) = _productService.GetProducts(model.PageIndex, model.PageSize,
                    model.FormatSortExpression("Name","Price","Description", "Id"), model.Search);

                
                var products = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = (from record in data
                            select new string[]
                            {
                            HttpUtility.HtmlEncode(record.Name),
                            HttpUtility.HtmlEncode(record.Price),
                            HttpUtility.HtmlEncode(record.Description),
                           // record.Rating.ToString(),
                            record.Id.ToString()
                            }).ToArray()


                };
               return Json(products);
            }

            catch(Exception ex) 
            {
                _logger.LogError(ex, "There was a problem getting products");
                return Json(DataTables.EmptyResult); 
            }

        }

    }
}

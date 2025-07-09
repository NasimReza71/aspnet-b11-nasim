using AutoMapper;
using DevSkill.Inventory.Application.Exceptions;
using DevSkill.Inventory.Application.Features.Products.Commands;
using DevSkill.Inventory.Application.Features.Products.Queries;
using DevSkill.Inventory.Application.Services;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Services;
using DevSkill.Inventory.Infrastructure;
using DevSkill.Inventory.Web.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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

        public IActionResult IndexSP()
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
                    await _mediator.Send(productAddCommand);

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Product Added",
                        Type = ResponseTypes.Success
                    });

           
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
            var product = _productService.GetProduct(id);
            var model = _mapper.Map<UpdateProductModel>(product);

            
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateProductModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var command = _mapper.Map<ProductUpdateCommand>(model);
                    await _mediator.Send(command);
                    
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
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                
                await _mediator.Send(new ProductDeleteCommand { Id = id });
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
        public async Task<JsonResult> GetProductsJsonData([FromBody] ProductListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<ProductSearchDto>(model.SearchItem);

                var query = new GetProductsSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("Name", "Price", "Description", "Id"),
                    SearchItem = searchDto
                };

                var (data, total, totalDisplay) = await _mediator.Send(query);

                var products = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(record => new string[]
                    {
                HttpUtility.HtmlEncode(record.Name),
                HttpUtility.HtmlEncode(record.Price),
                HttpUtility.HtmlEncode(record.Description),
                record.Id.ToString()
                    }).ToArray()
                };

                return Json(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was a problem getting products");
                return Json(DataTables.EmptyResult);
            }
        }


        [HttpPost]
        public async Task<JsonResult> GetProductsJsonDataSP([FromBody] ProductListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<ProductSearchDto>(model.SearchItem);

                var query = new GetProductsSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("Name", "Price", "Description", "Id"),
                    SearchItem = searchDto
                };

                var (data, total, totalDisplay) = await _mediator.Send(query);

                var products = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(record => new string[]
                    {
                        HttpUtility.HtmlEncode(record.Name),
                        HttpUtility.HtmlEncode(record.Price),
                        HttpUtility.HtmlEncode(record.Description),
                        record.Id.ToString()
                    }).ToArray()


                };
                return Json(products);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "There was a problem getting products");
                return Json(DataTables.EmptyResult);
            }

        }
    }
}

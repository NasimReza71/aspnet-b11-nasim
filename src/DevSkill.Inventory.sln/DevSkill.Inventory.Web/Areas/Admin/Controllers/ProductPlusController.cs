using AutoMapper;
using DevSkill.Inventory.Application.Features.ProductPlus.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models;
using DevSkill.Inventory.Web.Areas.Admin.Models.ProductPlusModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductPlusController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductPlusController> _logger;

        public ProductPlusController(IMediator mediator, IMapper mapper, ILogger<ProductPlusController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        // ProductPlus List
        public IActionResult ProductPlusList()
        {
            return View();
        }

        // Get ProductPlus Data for DataTables
        [HttpPost]
        public async Task<JsonResult> GetProductPlusJsonData([FromBody] ProductPlusListModel model)
        {
            try
            {
                // Mapping the search items from the view model
                var searchDto = _mapper.Map<ProductPlusSearchDto>(model.SearchItem);

                var query = new GetProductPlusSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("ProductCode", "ProductName", "Category", "StockQuantity"),
                    SearchItem = searchDto
                };

                // Sending the query and fetching data from the database
                var (data, total, totalDisplay) = await _mediator.Send(query);

                // Returning the result in DataTable format
                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(p => new string[]
                    {
                        p.Id.ToString(),
                        HttpUtility.HtmlEncode(p.ProductCode),  
                        HttpUtility.HtmlEncode(p.ProductName),  
                        HttpUtility.HtmlEncode(p.Category),     
                        p.PurchasePrice.ToString("N2"),        
                        p.MRP.ToString("N2"),                 
                        p.WholesalePrice.ToString("N2"),        
                        p.StockQuantity.ToString(),             
                        p.LowStockThreshold.ToString(),        
                        p.DamageStock.ToString(),              
                        p.ImagePath                            
                                               
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading ProductPlus data");
                return Json(DataTables.EmptyResult); 
            }
        }

       
        public async Task<IActionResult> ViewProductPlus(Guid id)
        {
            var productPlus = await _mediator.Send(new GetProductPlusByIdQuery { Id = id });
            if (productPlus == null) return NotFound();

            
            return View(productPlus); 
        }
    }
}

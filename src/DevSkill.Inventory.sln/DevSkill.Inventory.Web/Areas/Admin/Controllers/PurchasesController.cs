using AutoMapper;
using DevSkill.Inventory.Application.Features.Purchases.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Web.Areas.Admin.Models.PurchaseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PurchasesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<PurchasesController> _logger;

        public PurchasesController(IMediator mediator, IMapper mapper, ILogger<PurchasesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PurchaseList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetPurchasesJsonData([FromBody] PurchaseListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<PurchaseSearchDto>(model.SearchItem);

                var query = new GetPurchasesSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("PurchaseInvoice", "Name", "Products", "Total", "Paid", "Due"),
                    SearchItem = searchDto
                };

                var (data, total, totalDisplay) = await _mediator.Send(query);

                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(p => new string[]
                    {
                        HttpUtility.HtmlEncode(p.PurchaseInvoice),
                        HttpUtility.HtmlEncode(p.Name),
                        HttpUtility.HtmlEncode(p.Products),
                        p.Total.ToString("N2"),
                        p.Paid.ToString("N2"),
                        p.Due.ToString("N2"),
                        p.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading purchases");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}

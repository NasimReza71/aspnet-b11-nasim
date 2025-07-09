using AutoMapper;
using DevSkill.Inventory.Application.Features.Sales.Queries;
using DevSkill.Inventory.Application.Features.SalesReturns.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models.SalesModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SalesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<SalesController> _logger;

        public SalesController(IMediator mediator, IMapper mapper, ILogger<SalesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

  
        public IActionResult SalesList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetSalesJsonData([FromBody] SalesListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<SaleSearchDto>(model.SearchItem);

                var query = new GetSalesSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("InvoiceNumber", "CustomerName", "CustomerMobile", "Total", "Paid", "Due"),
                    SearchItem = searchDto
                };

                var (data, total, totalDisplay) = await _mediator.Send(query);

                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(s => new string[]
                    {
                        s.InvoiceNumber,
                        $"{s.CustomerName}<br/>{s.CustomerMobile}",
                        s.TotalAmount.ToString("N2"),
                        s.Paid.ToString("N2"),
                        s.Due.ToString("N2"),
                        s.Status,
                        s.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error loading sales");
                return Json(DataTables.EmptyResult);
            }
        }

      
        public IActionResult SalesReturnList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetSalesReturnsJsonData([FromBody] SalesReturnListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<SalesReturnSearchDto>(model.SearchItem);

                var query = new GetSalesReturnsSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("ReturnInvoice", "Customer", "Mobile", "Total", "Charge", "Paid"),
                    SearchItem = searchDto
                };

                var (data, total, totalDisplay) = await _mediator.Send(query);

                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select((r, index) => new string[]
                    {
                        (index + 1).ToString(),
                        r.Date.ToString("dd-MM-yyyy"),
                        $"<a href='#'>{HttpUtility.HtmlEncode(r.ReturnInvoice)}</a>",
                        $"{HttpUtility.HtmlEncode(r.Customer)}<br/>{HttpUtility.HtmlEncode(r.Mobile)}",
                        r.Quantity.ToString(),
                        r.Total.ToString("N2"),
                        r.Charge.ToString("N2"),
                        r.Paid.ToString("N2"),
                        r.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error loading sales return data");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}

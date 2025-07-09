using AutoMapper;
using DevSkill.Inventory.Application.Features.Quotations.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models;
using DevSkill.Inventory.Web.Areas.Admin.Models.QuotationsModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class QuotationsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<QuotationsController> _logger;

        public QuotationsController(IMediator mediator, IMapper mapper, ILogger<QuotationsController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult QuotationList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetQuotationsJsonData([FromBody] QuotationListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<QuotationSearchDto>(model.SearchItem);

                var query = new GetQuotationsSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("QuotationNumber", "QuotationDate", "CustomerName", "Quantity", "TotalPrice"),
                    SearchItem = searchDto
                };

                var (data, total, totalDisplay) = await _mediator.Send(query);

                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(q => new string[]
                    {
                        HttpUtility.HtmlEncode(q.Id),
                        HttpUtility.HtmlEncode(q.QuotationNumber),
                        q.QuotationDate.ToString("dd-MM-yyyy"),
                        HttpUtility.HtmlEncode(q.CustomerName),
                        q.Quantity.ToString(),
                        q.TotalPrice.ToString("N2"),
                        q.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading quotations");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}
